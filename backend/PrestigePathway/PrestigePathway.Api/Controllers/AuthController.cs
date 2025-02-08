using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServiceAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Auth/Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginRequest)
        {
            try
            {
                var token = await _authService.LoginAsync(loginRequest.Username, loginRequest.Password);
                return Ok(new { Token = token });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        // POST: api/Auth/Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User registerRequest)
        {
            try
            {
                await _authService.RegisterAsync(registerRequest);
                return Ok(new { Message = "User registered successfully." });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(ex.Errors);
            }
        }
    }
}