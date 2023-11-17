using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using Skymey_main_lib.Models;
using Skymey_main_lib.Models.Prices;
using Skymey_main_lib.Models.Prices.Okex;
using Skymey_main_lib.Models.Prices.StockPrices;
using Skymey_main_lib.Models.Tickers.Polygon;

namespace Skymey_mongodb.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Exchanges> Exchanges { get; init; }
        public DbSet<StockPrices> StockPrices { get; init; }
        public DbSet<CurrentPrices> CryptoCurrentPrices { get; init; }
        public DbSet<OkexCurrentPrices> OkexCurrentPricesView { get; init; }
        public DbSet<TickerList> TickerList { get; init; }
        public static ApplicationContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<ApplicationContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Exchanges>().ToCollection("crypto_exchanges");
            modelBuilder.Entity<StockPrices>().ToCollection("stock_current_prices");
            modelBuilder.Entity<CurrentPrices>().ToCollection("crypto_current_prices");
            modelBuilder.Entity<OkexCurrentPrices>().ToCollection("crypto_current_okex_prices");
            modelBuilder.Entity<TickerList>().ToCollection("stock_tickerlist");
        }
    }
}
