using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrestigePathway.DataAccessLayer.Abstractions.ServicesAbstractions;
using PrestigePathway.DataAccessLayer.Models;

namespace PrestigePathway.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : BaseController<Client, IClientService>
    {
        public ClientController(IClientService clientService, ILogger<ClientController> logger)
            : base(clientService, logger)
        {
        }

        protected override int GetEntityId(Client entity) => entity.ID; 

        [HttpGet("SearchClientByName")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Client>>> SearchClients(string name)
        {
            var clients = await _service.SearchClientsByNameAsync(name);
            return Ok(clients);
        }
    }
}