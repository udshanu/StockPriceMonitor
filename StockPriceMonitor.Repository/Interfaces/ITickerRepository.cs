using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface ITickerRepository
    {
        IEnumerable<Ticker> GetAllTickers();
        Ticker GetTickerById(int Id);
        void CreateTicker(Ticker ticker);
    }
}
