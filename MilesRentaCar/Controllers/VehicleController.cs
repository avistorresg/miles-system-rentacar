using Microsoft.AspNetCore.Mvc;
using MilesRentaCar.Interfaces;

namespace MilesRentaCar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService) 
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// Método que devuelve los vehículos disponibles usando la ciudad de ubicación del cliente
        /// y la ciudad de retorno del vehiculo; consume el servicio _vehicleService el cual se invoca 
        /// a través de inyeccion de dependencias con la interfaz IVehicleService, en este metodo se devuelve un listado 
        /// </summary>
        /// <param name="pickupLocationCity">Ciudad de Origen</param>
        /// <param name="returnLocationCity">Ciudad de Retorno</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAvailableVehicles")]
        public IActionResult GetAvailableVehicles(string pickupLocationCity, string returnLocationCity)
        {
            var vehicles = _vehicleService.GetAvailableVehicles(pickupLocationCity, returnLocationCity);
            if (!ModelState.IsValid) 
            { 
                return BadRequest(ModelState);
            }
            return Ok(vehicles);
        }
    }
}
