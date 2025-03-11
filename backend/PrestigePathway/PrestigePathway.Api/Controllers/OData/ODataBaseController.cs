using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using PrestigePathway.DataAccessLayer;

namespace PrestigePathway.Api.Controllers.OData
{
    public abstract class ODataBaseController<T> : ODataController where T : class
    {
        protected readonly SocialServicesDbContext _context;

        protected ODataBaseController(SocialServicesDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        public virtual IActionResult Get()
        {
            return Ok(_context.Set<T>());
        }

        [EnableQuery]
        public virtual async Task<IActionResult> Get([FromRoute] int key)
        {
            var entity = await _context.Set<T>().FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }
    }
}
