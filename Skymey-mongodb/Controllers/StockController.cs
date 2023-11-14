using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Skymey_main_lib.Models;
using Skymey_main_lib.Models.Prices.StockPrices;
using Skymey_mongodb.Data;

namespace Skymey_mongodb.Controllers
{
    [ApiController]
    [Route("api/Stock")]
    public class StockController : ControllerBase
    {
        private static MongoClient _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
        private ApplicationContext _db = ApplicationContext.Create(_mongoClient.GetDatabase("skymey"));
        public StockController() {

        }
        [HttpGet]
        [Route("GetPrices")]
        public async Task<List<StockPrices>> GetPrices()
        {
            return (from i in _db.StockPrices select new StockPrices { Ticker = i.Ticker, Figi = i.Figi, Price = i.Price, Currency = i.Currency, Update = i.Update }).ToList();
        }
        ~StockController() { }
    }
}
