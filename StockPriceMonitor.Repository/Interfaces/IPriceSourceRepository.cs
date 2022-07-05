using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IPriceSourceRepository
    {
        IEnumerable<PriceSource> GetAllPriceSourcesIncludingTickers();
        PriceSource GetPriceSourceById(int Id);
        bool CreatePriceSource(PriceSource priceSource);
    }
}
