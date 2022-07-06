using StockPriceMonitor.Entities.Models;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface ITickerRepository
    {
        bool CreateTicker(Ticker ticker);
    }
}
