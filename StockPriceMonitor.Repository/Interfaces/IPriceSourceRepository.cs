using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IPriceSourceRepository
    {
        IEnumerable<PriceSource> GetAllPriceSourcesIncludingTickers();
        bool CreatePriceSource(PriceSource priceSource);
    }
}
