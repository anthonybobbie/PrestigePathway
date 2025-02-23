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
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] User  user)
        {
            var token = await _authService.RegisterAsync(user);

            if (token == null)
            {
                return Unauthorized("Invalid username or password.");
            }


            return Ok(new { Token = token });
        }


    }
}