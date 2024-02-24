using MilesRentaCar.DataModel.Models;

namespace MilesRentaCar.Interfaces
{
    public interface IClientService
    {
        /// <summary>
        /// Definicion de metodo para obtener los clientes del sistema
        /// </summary>
        /// <returns></returns>
        IEnumerable<Client> GetClients();
    }
}
