using MilesRentaCar.DataModel.Context;
using MilesRentaCar.DataModel.Models;
using MilesRentaCar.Interfaces;

namespace MilesRentaCar.Services
{
    public class ClientService : IClientService
    {
        private readonly MilesRentaCarContext _dbContext;

        public ClientService(MilesRentaCarContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Implementacion del metodo que trae los clientes existentes en el sistema
        /// con su ubicación
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Client> GetClients()
        {
            var clientList = (from c in _dbContext.Clients
                              join l in _dbContext.Locations! on c.Location!.Id equals l.Id
                              select new Client 
                              { 
                                Id = c.Id,
                                FirstName = c.FirstName,
                                LastName = c.LastName,
                                Email = c.Email,
                                MobilePhone = c.MobilePhone,
                                OtherPhone = c.OtherPhone,
                                Location = l
                              }).ToList();
            return clientList;
        }
    }
}
