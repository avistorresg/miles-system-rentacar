using Microsoft.AspNetCore.Mvc;
using MilesRentaCar.DataModel.Models;
using MilesRentaCar.Interfaces;

namespace MilesRentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService) 
        {
            _marketService = marketService;
        }

        /// <summary>
        /// Método que devuelve los vehículos disponibles usando la ciudad de ubicación del cliente
        /// y la ciudad de retorno del vehiculo; consume el servicio _marketService el cual se invoca 
        /// a través de inyeccion de dependencias con la interfaz IMarketService, en este metodo se devuelve un listado
        /// y entre sus campos esta el Area del Mercado (MarketArea)
        /// </summary>
        /// <param name="cityClientLocation">Nombre de la ciudad donde se encuentra el cliente</param>
        /// <param name="cityReturnLocation">Nombre de la ciudad de retorno</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAvailableVehiclesByMarket")]
        public IActionResult GetVehiclesByMarket(string cityClientLocation, string cityReturnLocation)
        {
            var vehiclesByMarket = _marketService.GetMarketList(cityClientLocation, cityReturnLocation);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(vehiclesByMarket);
        }
    }
}
