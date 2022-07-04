using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IStockPriceRepository
    {
        StockPrice GetStockPriceById(int Id);
        void CreateStockPrice(StockPrice stockPrice);
        IEnumerable<StockPrice> GetLastFiveStockPrices(int tickerId);
    }
}
