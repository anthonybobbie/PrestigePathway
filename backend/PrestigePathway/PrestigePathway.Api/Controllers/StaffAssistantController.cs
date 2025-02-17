using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.ServiceLocation;
using PrestigePathway.Data.Models.StaffAssisstant;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class StaffAssistantController : BaseController<StaffAssistant, IStaffAssistantService, StaffAssisstantResponse,StaffAssisstantPostRequest,StaffAssisstantPutRequest>
    {
 
        public StaffAssistantController(IService<StaffAssistant, StaffAssisstantResponse> staffAssistantService, ILogger<StaffAssistantController> logger) : base(staffAssistantService, logger)
        {
        }

        protected override int GetEntityId(StaffAssistant entity) => entity.ID;
    }
}