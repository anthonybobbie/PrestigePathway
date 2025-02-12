using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions;

namespace PrestigePathway.Api.Controllers
{
    public class BaseController<TEntity, TService> : ControllerBase
        where TEntity : class
        where TService : IService<TEntity>
    {
        protected readonly TService _service;
        protected readonly ILogger<BaseController<TEntity, TService>> _logger;

        public BaseController(TService service, ILogger<BaseController<TEntity, TService>> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/[controller]
        [HttpGet("GetAll[controller]s")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            try
            {
                var entities = await _service.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching entities.");
                return HandleError(ex, "An error occurred while fetching entities.");
            }
        }

        // GET: api/[controller]/5
        [HttpGet("{id}/Get[controller]ById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<TEntity>> GetById(int id)
        {
            try
            {
                var entity = await _service.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound();
                }

                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching the entity with ID {id}.");
                return HandleError(ex, $"An error occurred while fetching the entity with ID {id}.");
            }
        }

        // POST: api/[controller]
        [HttpPost("Create[controller]")]
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
        [HttpPut("{id}/Update[controller]")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> Update(int id, TEntity entity)
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
        [HttpDelete("{id}/Delete[controller]")]
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
        protected virtual int GetEntityId(TEntity entity)
        {
            // Implement logic to get the ID of the entity (e.g., using reflection or a base interface)
            throw new NotImplementedException("GetEntityId must be implemented in derived controllers.");
        }
    }
}