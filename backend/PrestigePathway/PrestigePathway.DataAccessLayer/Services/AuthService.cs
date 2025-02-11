using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.DataAccessLayer.Abstractions.RepositoryAbstractions;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValidationException = FluentValidation.ValidationException;

namespace PrestigePathway.DataAccessLayer.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IValidator<User> _userValidator;

        public AuthService(IUserRepository userRepository, IConfiguration configuration, IValidator<User> userValidator)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _userValidator = userValidator;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Username and password are required.");
            }

            // Fetch user from the repository
            var user = await _userRepository.GetUserByUsernameAsync(username);

            // Check if the user exists and the password matches
            if (user == null || user.Password != password)
            {
                throw new UnauthorizedAccessException("Invalid username or password.");
            }

            // Generate and return a JWT token
            return GenerateJwtToken(user);
        }

        public async Task RegisterAsync(User user)
        {
            // Validate the user object
            var validationResult = await _userValidator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            // Check if the username already exists
            if (await _userRepository.GetUserByUsernameAsync(user.Username) != null)
            {
                throw new ArgumentException("Username already exists.");
            }

            // Add the user to the database via the repository
            await _userRepository.AddUserAsync(user);
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
               new Claim(ClaimTypes.Name, user.Username)
            };

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

    }
}