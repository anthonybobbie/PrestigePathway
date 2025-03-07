using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Api.Infrastructure;
using PrestigePathway.Data.Abstractions;
namespace PrestigePathway.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseController<TEntity, TService, TResponse, TCreateDto, TUpdateDto> : ControllerBase
             where TEntity : class
             where TService : IService<TEntity, TResponse>
             where TResponse : class
    {
        protected readonly IService<TEntity, TResponse> _service;
        protected readonly ILogger<BaseController<TEntity, TService, TResponse, TCreateDto, TUpdateDto>> _logger;

        public BaseController(IService<TEntity, TResponse> service, ILogger<BaseController<TEntity, TService, TResponse, TCreateDto, TUpdateDto>> logger)
        {
            _service = service;
            _logger = logger;
        }

        protected string ControllerName => GetType().Name.Replace("Controller", ""); // Get dynamic controller name

        // GET: api/[controller]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var permission = $"{ControllerName}_GET"; // Dynamically set permission
                var authorizationService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authResult = await authorizationService.AuthorizeAsync(User, null, new PermissionRequirement(permission));

                if (!authResult.Succeeded)
                {
                    return Forbid();
                }

                var entities = await _service.GetAllAsync();
                return DataResponse("Fetched successfully", entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching entities.");
                return HandleError(ex, "An error occurred while fetching entities.");
            }
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<IActionResult> GetById(int id)
        {
            try
            {
                var permission = $"{ControllerName}_GET";
                var authorizationService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authResult = await authorizationService.AuthorizeAsync(User, null, new PermissionRequirement(permission));

                if (!authResult.Succeeded)
                {
                    return Forbid();
                }

                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound(new ApiResponse<object> { Success = false, Message = "Entity not found." });
                }
                return DataResponse("Fetched successfully", entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the entity with ID {id}.");
                return HandleError(ex, $"An error occurred while fetching the entity with ID {id}.");
            }
        }

        // POST: api/[controller]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public virtual async Task<ActionResult<ApiResponse<TResponse>>> Create(TCreateDto createDto)
        {
            try
            {
                var permission = $"{ControllerName}_POST";
                var authorizationService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authResult = await authorizationService.AuthorizeAsync(User, null, new PermissionRequirement(permission));

                if (!authResult.Succeeded)
                {
                    return Forbid();
                }

                var entity = createDto.Adapt<TEntity>();
                var createdEntity = await _service.AddAsync(entity);
                var response = await _service.GetByIdAsync(GetEntityId(entity));

                return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) },
                    new ApiResponse<TResponse> { Success = true, Message = "Entity created successfully", Data = response });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the entity.");
                return HandleError(ex, "An error occurred while creating the entity.");
            }
        }

        // PUT: api/[controller]/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> Update([FromRoute] int id, TEntity entity)
        {
            try
            {
                var permission = $"{ControllerName}_PUT";
                var authorizationService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authResult = await authorizationService.AuthorizeAsync(User, null, new PermissionRequirement(permission));

                if (!authResult.Succeeded)
                {
                    return Forbid();
                }

                if (id != GetEntityId(entity))
                {
                    return BadRequest(new ApiResponse<object> { Success = false, Message = "Mismatched ID in request." });
                }

                var existingEntity = await _service.GetByIdAsync(id);
                if (existingEntity == null)
                {
                    return NotFound(new ApiResponse<object> { Success = false, Message = "Entity not found." });
                }

                await _service.UpdateAsync(entity);
                return Ok(new ApiResponse<TResponse> { Success = true, Message = "Entity updated successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the entity with ID {id}.");
                return HandleError(ex, $"An error occurred while updating the entity with ID {id}.");
            }
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> Delete(int id)
        {
            try
            {
                var permission = $"{ControllerName}_DELETE";
                var authorizationService = HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();
                var authResult = await authorizationService.AuthorizeAsync(User, null, new PermissionRequirement(permission));

                if (!authResult.Succeeded)
                {
                    return Forbid();
                }

                var entity = await _service.GetByIdAsync(id);
                if (entity == null)
                {
                    return NotFound(new ApiResponse<object> { Success = false, Message = "Entity not found." });
                }

                await _service.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the entity with ID {id}.");
                return HandleError(ex, $"An error occurred while deleting the entity with ID {id}.");
            }
        }

        // Helper method to handle errors
        protected ActionResult HandleError(Exception ex, string message)
        {
            return StatusCode(500, new ApiResponse<object> { Success = false, Message = message, Data = ex.Message });
        }

        // Helper method to get the ID of an entity (must be implemented by derived classes)
        protected abstract int GetEntityId(TEntity entity);

        // Helper method for standardized API responses
        protected ActionResult DataResponse<T>(string message, T data, bool success = true)
        {
            return Ok(new ApiResponse<T>
            {
                Success = success,
                Message = message,
                Data = data
            });
        }
    }

    // Standardized API response model
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
