using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IPriceSourceRepository
    {
        bool SaveChanges();

        IEnumerable<PriceSource> GetAllPriceSources();
        void CreatePriceSource(PriceSource priceSource);
    }
}
