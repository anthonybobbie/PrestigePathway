using System;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.DataAccessLayer.Abstractions;
using PrestigePathway.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using PrestigePathway.Data.Models.Auth;
using PrestigePathway.Data.Models.UserRole;
using ValidationException = FluentValidation.ValidationException;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PrestigePathway.Data.Utilities;

namespace PrestigePathway.Data.Services
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<User> _userValidator;
        private readonly IRepository<UserRole> _userRolesRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IValidator<ChangePasswordRequest> _changePasswordValidator;

        public AuthService(IRepository<User> userRepository, IRepository<Role> roleRepository, IConfiguration configuration, IValidator<User> userValidator, IRepository<UserRole> userRolesRepository, IValidator<ChangePasswordRequest> changePasswordValidator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userValidator = userValidator;
            _userRolesRepository = userRolesRepository;
            _roleRepository = roleRepository;
            _changePasswordValidator = changePasswordValidator;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            // Fetch user from the repository
            var user = await _userRepository.Query().FirstOrDefaultAsync(x=>x.Username == username);

            // Verify the provided password against the stored hashed password
            if (user == null || !VerifyPassword(user.Password, password))
            {
                throw new ArgumentException("Invalid username or password");
            }

            // Generate and return a JWT token
            return await GenerateJwtToken(user);
        }

        public async Task<User> RegisterAsync(User user)
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
            return await _userRepository.AddAsync(user);
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            // Fetch user roles
            var userRoles = _userRolesRepository.Query().Where(x => x.UserID == user.ID);
            
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

            var roles = from userRole in _userRolesRepository.Query()
                join role in _roleRepository.Query() on userRole.UserID equals role.ID
                select role.Name;
            foreach (var _role in roles)
            {
                if (!string.IsNullOrEmpty(_role))
                {
                    claims.Add(new Claim(_role, _role));
                }
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
            //using (var sha256 = SHA256.Create())
            //{
            //    byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            //    byte[] hashedBytes = sha256.ComputeHash(passwordBytes);
            //    return Convert.ToBase64String(hashedBytes);
            //}

            // Generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[16];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(salt);
            }

            // Derive a 256-bit subkey
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100_000,
                numBytesRequested: 32
            ));

            // Combine the salt and the hash into a single string
            return $"{Convert.ToBase64String(salt)}:{hashed}";
        }

        private bool VerifyPassword(string hashedPassowrd, string providedPassword)
        {
            // Split the hashed password into salt and hash
            var parts = hashedPassowrd.Split(":");
            var salt = Convert.FromBase64String(parts[0]);
            var storedHash = parts[1];

            // Hash the provided password with the same salt
            var hashProvidedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: providedPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100_000,
                numBytesRequested: 32
            ));

            // Compare the hashes
            return storedHash == hashProvidedPassword;
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