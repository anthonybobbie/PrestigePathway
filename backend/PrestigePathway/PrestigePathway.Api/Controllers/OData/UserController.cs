using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using PrestigePathway.Data.Models.User;
using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class UserController : ODataBaseController<User>
    {
        public UserController(SocialServicesDbContext context) : base(context) { }

        [EnableQuery]
        public override IActionResult Get()
        {
            var dto = _context.Set<User>().ToList();
            return Ok(dto.Adapt<List<UserDto>>());
        }
    }
}