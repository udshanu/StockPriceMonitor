using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Controllers.Tests.MockData
{
    public class StockPriceMockData
    {
        public static List<StockPrice> GetLastFiveStockPrices()
        {
            return new List<StockPrice>
            {
                 new StockPrice() { Id = 10, TickerId = 2, Price = 259.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(11) },
                new StockPrice() { Id = 11, TickerId = 2, Price = 269.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(12) },
                new StockPrice() { Id = 12, TickerId = 2, Price = 279.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(13) },
                new StockPrice() { Id = 13, TickerId = 2, Price = 289.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(14) },
                new StockPrice() { Id = 14, TickerId = 2, Price = 299.33M, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(15) },
            };
        }

        public static List<StockPrice> GetZeroLastFiveStockPrices()
        {
            return new List<StockPrice>();
        }

        public static List<StockPrice> GetNullLastFiveStockPrices()
        {
            return null;
        }

        public static StockPrice CreateStockPrice()
        {
            return new StockPrice
            {
                TickerId = 3,
                Price = 750.53M,
                CreatedBy = "System",
                DateCreated = DateTime.Now
            };
        }

        public static StockPriceRequestDTO GetRequestedStockPrice()
        {
            return new StockPriceRequestDTO
            {
                TickerId = 3,
                Price = 750.53M
            };
        }


    }
}
