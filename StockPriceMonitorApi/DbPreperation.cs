using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                        new PriceSource() { Id = 3, Name = "Source 3", IsDeleted = false, CreatedBy = "System", DateCreated = currentDate }
                    );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Already have data.");
            }
        }
    }
}
