using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface ITickerRepository
    {
        Ticker GetTickerById(int Id);
        void CreateTicker(Ticker ticker);
    }
}
