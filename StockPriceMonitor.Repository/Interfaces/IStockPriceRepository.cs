using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IStockPriceRepository
    {
        bool CreateStockPrice(StockPrice stockPrice);
        IEnumerable<StockPrice> GetLastFiveStockPrices(int tickerId);
    }
}
