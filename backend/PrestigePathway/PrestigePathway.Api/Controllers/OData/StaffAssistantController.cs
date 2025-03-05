using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class StaffAssistantController : ODataBaseController<StaffAssistant>
    {
        public StaffAssistantController(SocialServicesDbContext context) : base(context) { }
    }
}