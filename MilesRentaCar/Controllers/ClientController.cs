using Microsoft.AspNetCore.Mvc;
using MilesRentaCar.DataModel.Models;
using MilesRentaCar.Interfaces;

namespace MilesRentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService) 
        {
            _clientService = clientService;
        }

        /// <summary>
        /// Metodo que devuelve un listado de los clientes existentes en el sistema
        /// haciendo un llamado al metodo GetClients del servicio ClientService, invocado a través
        /// de inyección de dependencias con la interfaz IClientService
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetClients")]
        public IActionResult GetClientList()
        {
            var clients = _clientService.GetClients();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(clients);
        }
    }
}
