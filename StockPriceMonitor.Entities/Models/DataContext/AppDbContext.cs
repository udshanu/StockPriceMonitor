using Microsoft.EntityFrameworkCore;

namespace StockPriceMonitor.Entities.Models.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<PriceSource> PriceSources { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
    }
}
