using PrestigePathway.Data.Abstractions;
using PrestigePathway.Data.Models.Client;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{

    public class ClientController : BaseController<Client, IClientService, ClientResponse>
    {
        public ClientController(IService<Client, ClientResponse> clientService, ILogger<ClientController> logger)
            : base(clientService, logger)
        {
        }

        protected override int GetEntityId(Client entity) => entity.ID;
    }
}