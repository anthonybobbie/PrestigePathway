using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Location;
using PrestigePathway.Data.Models.Partner;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class PartnerController : BaseController<Partner, IPartnerService, PartnerResponse>
    {
     
        public PartnerController(IService<Partner, PartnerResponse> partnerService, ILogger<PartnerController> logger) 
            : base(partnerService, logger) 
        {
        }

        protected override int GetEntityId(Partner entity)
        {
            throw new NotImplementedException();
        }
    }
}