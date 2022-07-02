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
                Console.WriteLine("--> Seeding data.");

                var currentDate = DateTime.Now;

                context.PriceSources.AddRange(
                        new PriceSource() { Id = 1, Name = "Source 1", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 2, Name = "Source 2", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 3, Name = "Source 3", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 4, Name = "Source 4", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 5, Name = "Source 5", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 6, Name = "Source 6", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new PriceSource() { Id = 7, Name = "Source 7", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate, UpdatedBy = "System 2", DateLastUpdated = currentDate }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Already have price source data.");
            }

            if (!context.Tickers.Any())
            {
                Console.WriteLine("--> Seeding data.");

                var currentDate = DateTime.Now;

                context.Tickers.AddRange(
                        new Ticker() { Id = 1, TickerName = "Ticker 1", PriceSourceId = 4, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new Ticker() { Id = 2, TickerName = "Ticker 2", PriceSourceId = 4, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new Ticker() { Id = 3, TickerName = "Ticker 3", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new Ticker() { Id = 4, TickerName = "Ticker 4", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new Ticker() { Id = 5, TickerName = "Ticker 5", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate },
                        new Ticker() { Id = 6, TickerName = "Ticker 6", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = currentDate }

                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Already have ticker data.");
            }
        }
    }
}
