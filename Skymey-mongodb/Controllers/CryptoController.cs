using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Skymey_main_lib.Models;
using Skymey_main_lib.Models.CryptoCurrentPricesView;
using Skymey_main_lib.Models.Prices;
using Skymey_main_lib.Models.Prices.StockPrices;
using Skymey_mongodb.Data;

namespace Skymey_mongodb.Controllers
{
    [ApiController]
    [Route("api/Crypto")]
    public class CryptoController : ControllerBase
    {
        private static MongoClient _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
        private ApplicationContext _db = ApplicationContext.Create(_mongoClient.GetDatabase("skymey"));
        public CryptoController() {

        }
        [HttpGet]
        [Route("GetExchanges")]
        public async Task<HashSet<Exchanges>> GetExchanges()
        {
            return (from i in _db.Exchanges select new Exchanges { Name = i.Name, Volume24h = i.Volume24h, Trades = i.Trades, Pairs = i.Pairs, Type = i.Type, Blockchain = i.Blockchain }).ToHashSet();
        }
        [HttpGet]
        [Route("GetPrices")]
        public async Task<IQueryable<CurrentPrices>> GetPrices()
        {
            return (from i in _db.CryptoCurrentPrices select i);
        }
        ~CryptoController() { }
    }
}
