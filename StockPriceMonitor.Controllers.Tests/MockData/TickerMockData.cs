using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using System;

namespace StockPriceMonitor.Controllers.Tests.MockData
{
    public class TickerMockData
    {
        public static Ticker CreateTicker()
        {
            return new Ticker() { TickerName = "Ticker 7", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now };
        }

        public static TickerRequestDTO GetRequestedTicker()
        {
            return new TickerRequestDTO { TickerName = "Ticker 7", PriceSourceId = 6 };
        }
    }
}
