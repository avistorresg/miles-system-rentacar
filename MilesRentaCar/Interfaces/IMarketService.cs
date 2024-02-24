using MilesRentaCar.DataModel.Models;

namespace MilesRentaCar.Interfaces
{
    public interface IMarketService
    {
        /// <summary>
        /// Definicion de Metodo que trae los vehiculos disponibles incluyendo su area de mercado
        /// </summary>
        /// <param name="clientLocationCity">Ubicacion del Cliente</param>
        /// <param name="returnLocationCity">Ubicacion de Retorno</param>
        /// <returns></returns>
        IEnumerable<Market> GetMarketList(string clientLocationCity, string returnLocationCity);
    }
}
