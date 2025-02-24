using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Utilities;
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User  user)
        {
            var newUser = await _authService.RegisterAsync(user);

            if (newUser == null)
            {
                return Unauthorized("Invalid username or password.");
            }


            return Ok(new { NewUser = newUser });
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                await _authService.ChangePasswordAsync(request);

                return Ok("Password changed successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while changing the password.");
            }
        }
    }
}