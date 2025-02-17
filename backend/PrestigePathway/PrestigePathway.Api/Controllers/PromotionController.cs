using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Payment;
using PrestigePathway.Data.Models.Promotion;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class PromotionController : BaseController<Promotion, IPromotionService,PromotionResponse>
    {
         
        public PromotionController(IService<Promotion, PromotionResponse> promotionService, ILogger<PromotionController> logger) 
            : base(promotionService, logger)
        {
        }

        protected override int GetEntityId(Promotion entity) => entity.ID;
    }
}