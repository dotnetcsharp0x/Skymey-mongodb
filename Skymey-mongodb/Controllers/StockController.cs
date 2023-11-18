using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Skymey_main_lib.Models;
using Skymey_main_lib.Models.CryptoCurrentPricesView;
using Skymey_main_lib.Models.Dividends;
using Skymey_main_lib.Models.Dividends.Polygon;
using Skymey_main_lib.Models.Prices;
using Skymey_main_lib.Models.Prices.Polygon;
using Skymey_main_lib.Models.Prices.StockPrices;
using Skymey_main_lib.Models.Prices.StockPricesView;
using Skymey_main_lib.Models.Tickers;
using Skymey_main_lib.Models.Tickers.Polygon;
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
        public async Task<List<StockPricesView>> GetPrices()
        {
            List<StockPricesView> cp = new List<StockPricesView>();
            foreach (var item in (from i in _db.StockPrices select i).AsNoTracking())
            {
                StockPricesView? div = new StockPricesView();
                div.Ticker = item.Ticker;
                div.Figi = item.Figi;
                div.Price = item.Price;
                div.Currency = item.Currency;
                div.Update = item.Update;
                cp.Add(div);
                div = null;
            }
            return cp;
        }
        [HttpGet]
        [Route("GetShares")]
        public async Task<List<TickerList>> GetShares()
        {
            return (from i in _db.TickerList select i).AsNoTracking().ToList();
        }
        [HttpGet]
        [Route("GetDividends")]
        public async Task<List<StockDividends>> GetDividends(string ticker)
        {
            List<StockDividends> cp = new List<StockDividends>();
            var in_db = (from i in _db.DividendsPolygon where i.ticker == ticker select i).AsNoTracking();
            foreach (var item in in_db)
            {
                StockDividends? div = new StockDividends();
                div.Ticker = item.ticker;
                div.Cash_amount = item.cash_amount;
                div.Update = item.Update;
                div.Currency = item.currency;
                div.Declaration_date = item.declaration_date;
                div.Dividend_type = item.dividend_type;
                div.Ex_dividend_date = item.ex_dividend_date;
                div.Frequency = item.frequency;
                div.Pay_date = item.pay_date;
                div.Record_date = item.record_date;
                cp.Add(div);
                div = null;
            }
            return cp;
        }
        ~StockController() { }
    }
}
