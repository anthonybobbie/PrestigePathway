using PrestigePathway.DataAccessLayer;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers.OData
{
    public class ClientController : ODataBaseController<Client>
    {
        public ClientController(SocialServicesDbContext context) : base(context) { }
    }
}