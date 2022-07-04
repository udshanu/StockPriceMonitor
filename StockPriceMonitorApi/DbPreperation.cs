using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using System;
using System.Linq;

namespace StockPriceMonitor.Api
{
    public static class DbPreperation
    {
        public static void PreperationPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.PriceSources.Any())
            {
                context.PriceSources.AddRange(
                        new PriceSource() { Id = 1, Name = "Source 1", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1) },
                        new PriceSource() { Id = 2, Name = "Source 2", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2) },
                        new PriceSource() { Id = 3, Name = "Source 3", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3) },
                        new PriceSource() { Id = 4, Name = "Source 4", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4) },
                        new PriceSource() { Id = 5, Name = "Source 5", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5) },
                        new PriceSource() { Id = 6, Name = "Source 6", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6) },
                        new PriceSource() { Id = 7, Name = "Source 7", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(7), UpdatedBy = "System 2", DateLastUpdated = DateTime.Now.AddMinutes(8) }
                    );

                context.SaveChanges();
            }

            if (!context.Tickers.Any())
            {
                var currentDate = DateTime.Now;

                context.Tickers.AddRange(
                        new Ticker() { Id = 1, TickerName = "Ticker 1", PriceSourceId = 1, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1) },
                        new Ticker() { Id = 2, TickerName = "Ticker 2", PriceSourceId = 1, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2) },
                        new Ticker() { Id = 3, TickerName = "Ticker 3", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3) },
                        new Ticker() { Id = 4, TickerName = "Ticker 4", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4) },
                        new Ticker() { Id = 5, TickerName = "Ticker 5", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5) },
                        new Ticker() { Id = 6, TickerName = "Ticker 6", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6) }

                    );

                context.SaveChanges();
            }

            if (!context.StockPrices.Any())
            {

                context.StockPrices.AddRange(
                        new StockPrice() { Id = 1, TickerId = 1, Price = 139.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1) },
                        new StockPrice() { Id = 2, TickerId = 1, Price = 149.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2) },
                        new StockPrice() { Id = 3, TickerId = 1, Price = 159.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3) },
                        new StockPrice() { Id = 4, TickerId = 1, Price = 169.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4) },
                        new StockPrice() { Id = 5, TickerId = 1, Price = 179.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5), UpdatedBy = "System", DateLastUpdated = DateTime.Now.AddMinutes(7) },
                        new StockPrice() { Id = 6, TickerId = 1, Price = 189.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6) },
                        new StockPrice() { Id = 7, TickerId = 1, Price = 199.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(8) },
                        new StockPrice() { Id = 8, TickerId = 2, Price = 239.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(9) },
                        new StockPrice() { Id = 9, TickerId = 2, Price = 249.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(10) },
                        new StockPrice() { Id = 10, TickerId = 2, Price = 259.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(11) },
                        new StockPrice() { Id = 11, TickerId = 2, Price = 269.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(12) },
                        new StockPrice() { Id = 12, TickerId = 2, Price = 279.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(13) },
                        new StockPrice() { Id = 13, TickerId = 2, Price = 289.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(14) },
                        new StockPrice() { Id = 14, TickerId = 2, Price = 299.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(15) },
                        new StockPrice() { Id = 15, TickerId = 3, Price = 339.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(16) },
                        new StockPrice() { Id = 16, TickerId = 3, Price = 349.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(17) },
                        new StockPrice() { Id = 17, TickerId = 3, Price = 359.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(18) },
                        new StockPrice() { Id = 18, TickerId = 3, Price = 369.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(19) },
                        new StockPrice() { Id = 19, TickerId = 3, Price = 379.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(20) },
                        new StockPrice() { Id = 20, TickerId = 3, Price = 389.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(21) },
                        new StockPrice() { Id = 21, TickerId = 3, Price = 399.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(22) }
                    );

                context.SaveChanges();
            }
        }
    }
}
