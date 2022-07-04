using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IStockPriceRepository
    {
        //IEnumerable<StockPrice> GetAllStockPrices();
        StockPrice GetStockPriceById(int Id);
        void CreateStockPrice(StockPrice stockPrice);
        IEnumerable<StockPrice> GetLastFiveStockPrices(int tickerId);
    }
}
