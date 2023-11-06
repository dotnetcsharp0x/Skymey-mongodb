using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Skymey_main_lib.Models;
using Skymey_mongodb.Data;

namespace Skymey_mongodb.Controllers
{
    [ApiController]
    [Route("api/Mongo")]
    public class MongoController : ControllerBase
    {
        private static MongoClient _mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
        private ApplicationContext _db = ApplicationContext.Create(_mongoClient.GetDatabase("skymey"));
        public MongoController() {

        }
        [HttpGet]
        [Route("GetExchanges")]
        public async Task<HashSet<Exchanges>> GetExchanges()
        {
            return (from i in _db.Exchanges select new Exchanges { Name = i.Name, Volume24h = i.Volume24h, Trades = i.Trades, Pairs = i.Pairs, Type = i.Type, Blockchain = i.Blockchain }).ToHashSet();
        }
        ~MongoController() { }
    }
}
