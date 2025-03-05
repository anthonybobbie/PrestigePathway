using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class StaffController : ODataBaseController<Staff>
    {
        public StaffController(SocialServicesDbContext context) : base(context) { }
    }
}