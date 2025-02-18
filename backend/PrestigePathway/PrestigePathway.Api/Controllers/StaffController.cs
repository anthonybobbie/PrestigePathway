using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Staff;
using PrestigePathway.Data.Models.StaffAssisstant;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    public class StaffController : BaseController<Staff, IStaffService,StaffResponse,StaffPostRequest,StaffPutRequest>
    {
        
        public StaffController(IService<Staff, StaffResponse> staffService, ILogger<StaffController> logger)
            : base(staffService, logger) 
        { }

        protected override int GetEntityId(Staff entity) => entity.ID;
    }
}