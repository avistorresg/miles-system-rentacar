using MilesRentaCar.DataModel.Context;
using MilesRentaCar.DataModel.Models;
using MilesRentaCar.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MilesRentaCar.Services
{
    public class MarketService : IMarketService
    {
        private readonly MilesRentaCarContext _dbContext;

        public MarketService(MilesRentaCarContext dbContext) 
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Implementacion del metodo que trae los vehiculos disponibles con su area de Mercado
        /// </summary>
        /// <param name="clientLocationCity"></param>
        /// <param name="returnLocationCity"></param>
        /// <returns></returns>
        public IEnumerable<Market> GetMarketList(string clientLocationCity, string returnLocationCity)
        {
            var vehiclesByMarket = (from market in _dbContext.Markets
                                    join cl in _dbContext.Locations! on market.ClientLocation!.Id equals cl.Id
                                    join rl in _dbContext.Locations! on market.ReturnLocation!.Id equals rl.Id
                                    join v in _dbContext.Vehicles! on market.Vehicle!.Id equals v.Id
                                    where cl.City == clientLocationCity && rl.City == returnLocationCity
                                    select new Market 
                                    { 
                                        Id = market.Id,
                                        ClientLocation = cl,
                                        ReturnLocation = rl,
                                        Vehicle = v,
                                        MarketArea = market.MarketArea
                                    }).ToList();

            return vehiclesByMarket;
        }
    }
}
