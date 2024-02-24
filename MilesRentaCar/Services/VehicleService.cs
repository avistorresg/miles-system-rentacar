using Microsoft.EntityFrameworkCore;
using MilesRentaCar.DataModel.Context;
using MilesRentaCar.DataModel.Models;
using MilesRentaCar.Interfaces;

namespace MilesRentaCar.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly MilesRentaCarContext _dbContext;

        public VehicleService(MilesRentaCarContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Implementacion del metodo que trae los vehiculos disponibles segun su ubicacion de entrada y retorno
        /// </summary>
        /// <param name="pickupLocationCity"></param>
        /// <param name="returnLocationCity"></param>
        /// <returns></returns>
        public IEnumerable<Vehicle> GetAvailableVehicles(string pickupLocationCity, string returnLocationCity)
        {
            var availableVehicles = _dbContext.Vehicles!
                .Include(vehicle => vehicle.PickupLocation)
                .Include(vehicle => vehicle.ReturnLocation)
                .Where(vehicle => vehicle.PickupLocation!.City == pickupLocationCity && vehicle.ReturnLocation!.City == returnLocationCity)
                .ToList();

            return availableVehicles;
        }
    }
}
