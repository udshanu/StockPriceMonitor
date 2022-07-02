using StockPriceMonitor.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IPriceSourceRepository
    {
        bool SaveChanges();

        IEnumerable<PriceSource> GetAllPriceSources();
        void CreatePriceSource(PriceSource priceSource);
    }
}
