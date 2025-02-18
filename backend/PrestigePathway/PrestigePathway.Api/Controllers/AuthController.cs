using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _authService;

        public AuthController(IConfiguration configuration, IAuthService authService)
        {
            _configuration = configuration;
            _authService = authService;
        }

        // POST: api/Auth/Login
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] User loginRequest)
        {
            var token = await _authService.LoginAsync(loginRequest.Username,loginRequest.Password);

            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }

             
            return Ok(new { Token = token });
        }

        // Helper method to generate JWT token
        // private string GenerateJwtToken(User user)
        // {
        //     var jwtSettings = _configuration.GetSection("Jwt");
        //     var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
        //
        //     var tokenDescriptor = new SecurityTokenDescriptor
        //     {
        //         Subject = new ClaimsIdentity(new[]
        //         {
        //             new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
        //             new Claim(ClaimTypes.Name, user.Username)
        //         }),
        //         Expires = DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"])),
        //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        //         Issuer = jwtSettings["Issuer"],
        //         Audience = jwtSettings["Audience"]
        //     };
        //
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var token = tokenHandler.CreateToken(tokenDescriptor);
        //     return tokenHandler.WriteToken(token);
        // }

        //[HttpPost("register")]
        //public IActionResult Register([FromBody] User registerRequest)
        //{
        //    // Validate input
        //    if (Users.Any(u => u.Username == registerRequest.Username))
        //    {
        //        return BadRequest("Username already exists.");
        //    }

        //    // Add user to the store (replace with database logic)
        //    var newUser = new User
        //    {
        //        Id = Users.Count + 1,
        //        Username = registerRequest.Username,
        //        Password = registerRequest.Password // Hash the password in production
        //    };
        //    Users.Add(newUser);

        //    return Ok(new { Message = "User registered successfully." });
        //}
    }
}