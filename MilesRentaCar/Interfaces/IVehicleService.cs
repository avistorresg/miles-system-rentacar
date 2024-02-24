using MilesRentaCar.DataModel.Models;

namespace MilesRentaCar.Interfaces
{
    public interface IVehicleService
    {
        /// <summary>
        /// Definicion de metodo que trae el listado de vehiculos disponibles segun su 
        /// ubicacion de entrada y ubicacion de retorno
        /// </summary>
        /// <param name="pickupLocationCity">Ubicacion de origen</param>
        /// <param name="returnLocationCity">Ubicacion de retorno</param>
        /// <returns></returns>
        IEnumerable<Vehicle> GetAvailableVehicles(string pickupLocationCity, string returnLocationCity);
    }
}
