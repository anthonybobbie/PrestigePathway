using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.User;
using PrestigePathway.Data.Utilities;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;
using ValidationException = FluentValidation.ValidationException;

namespace PrestigePathway.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<User> _userValidator;
        private readonly IRepository<UserRole> _userRolesRepository;
        private readonly IRepository<RolePermission> _rolePermissionRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IValidator<ChangePasswordRequest> _changePasswordValidator;

        public AuthService(IRepository<User> userRepository, IRepository<Role> roleRepository, IConfiguration configuration, IValidator<User> userValidator,
            IRepository<UserRole> userRolesRepository,
            IRepository<RolePermission> rolePermissionRepository,
            IValidator<ChangePasswordRequest> changePasswordValidator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userValidator = userValidator;
            _userRolesRepository = userRolesRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _roleRepository = roleRepository;
            _changePasswordValidator = changePasswordValidator;
            _roleRepository = roleRepository;
        }

        public async Task<AuthUser> LoginAsync(string username, string password)
        {
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            // Fetch user from the repository
            var user = await _userRepository.Query().FirstOrDefaultAsync(x => x.Username == username);

            // Verify the provided password against the stored hashed password
            if (user == null || !VerifyPassword(password, user.Password))
            {
                throw new ArgumentException("Invalid username or password");
            }

            // Generate and return a JWT token
            return new AuthUser() { Token = await GenerateJwtToken(user), User = user.Adapt<UserDto>() };
        }

        public async Task<UserDto> RegisterAsync(User user)
        {
            // Validate the user object
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Check if the username already exists
            if (await _userRepository.Query().FirstOrDefaultAsync(x => x.Username == user.Username) != null)
            {
                throw new ArgumentException("Username already exists.");
            }

            // Add the user to the database via the repository
            user.Password = HashPassword(user.Password);
            var new_user = await _userRepository.AddAsync(user);
            return new_user.Adapt<UserDto>();
        }

        public async Task<string> GenerateJwtToken(User user)
        {


            var jwtSettings = _configuration.GetSection("Jwt");
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
               new Claim(ClaimTypes.Name, user.Username)

                // Add additional claims here...
                
            };


            // Fetch user roles
            var userRole = await _userRolesRepository.Query().FirstOrDefaultAsync(x => x.UserID == user.ID);
            if (userRole != null)
            {
                var rolePermissions = _rolePermissionRepository.Query().Include(x => x.Permission).Where(x => x.RoleID == userRole.RoleID);
                claims.AddRange(rolePermissions.Select(x => new Claim("Permission", x.Permission.Name)));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = jwtSettings["Issuer"],
                Audience = jwtSettings["Audience"],
                SigningCredentials = signingCredentials
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        private bool VerifyPassword(string providedPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword);
        }

        public async Task ChangePasswordAsync(ChangePasswordRequest request)
        {
            // Retrieve user
            var user = await _userRepository.Query().FirstOrDefaultAsync(u => u.Username == request.Username);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            // Verify current password
            if (!VerifyPassword(user.Password, request.CurrentPassword))
            {
                throw new ArgumentException("Current password is incorrect.");
            }

            // Validate new password (e.g. length, complexity)
            var validateNewPassword = await _changePasswordValidator.ValidateAsync(request);
            if (!validateNewPassword.IsValid)
            {
                throw new ValidationException(validateNewPassword.Errors);
            }

            user.Password = HashPassword(request.NewPassword);
            await _userRepository.UpdateAsync(user);
        }
    }
}