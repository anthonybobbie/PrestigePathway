using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class PaymentController : ODataBaseController<Payment>
    {
        public PaymentController(SocialServicesDbContext context) : base(context) { }
    }
}