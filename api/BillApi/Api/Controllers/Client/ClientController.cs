using BillApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace BillApi.Api.Controllers.Client
{
    [Route("api/client")]
    [ApiController]
    public class ClientController(IClientService clientService) : ControllerBase
    {
        private readonly IClientService _clientService = clientService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAll();

            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }
    }

}
