using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Booking;
using System.Net;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class BaseController<TEntity, TService,TResponse> : ControllerBase
        where TEntity : class
        where TService : IService<TEntity,TResponse>
    {
        protected readonly IService<TEntity, TResponse> _service;
        protected readonly ILogger<BaseController<TEntity, TService, TResponse>> _logger;

        public BaseController(IService<TEntity, TResponse> service, ILogger<BaseController<TEntity, TService, TResponse>> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/[controller]
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return DataResponse(string.Empty, entities, HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching entities.");
                return DataResponse<object>("An error occurred while fetching entities.",null, HttpStatusCode.InternalServerError);
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
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return DataResponse(string.Empty,entity, HttpStatusCode.OK);
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
        public virtual async Task<ActionResult<TEntity>> Create(TEntity entity)
        {
            try
            {
                await _service.AddAsync(entity);
                 
                return CreatedAtAction(nameof(GetById), new { id = GetEntityId(entity) }, entity);
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> Update([FromRoute] int id, TEntity entity)
        {
            try
            {
                if (id != GetEntityId(entity))
                {
                    return BadRequest();
                }

                await _service.UpdateAsync(entity);
                return NoContent();
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
            return StatusCode(500, new { Message = message, Details = ex.Message });
        }

        // Helper method to get the ID of an entity
        protected abstract int GetEntityId(TEntity entity);
         
        // Helper method to handle errors
        protected ActionResult DataResponse<T>(string ex, T Data, HttpStatusCode httpStatusCode)
        {
            return Ok(new DataResponse<T>() { ErrorMessage = ex, Data = Data, StatusCode = httpStatusCode });
        }


    }
    public class DataResponse<T>
    {
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}