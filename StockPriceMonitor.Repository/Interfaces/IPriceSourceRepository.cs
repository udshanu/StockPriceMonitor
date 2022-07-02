﻿using StockPriceMonitor.Entities.Models;
using System.Collections.Generic;

namespace StockPriceMonitor.Repository.Interfaces
{
    public interface IPriceSourceRepository
    {
        IEnumerable<PriceSource> GetAllPriceSources();
        PriceSource GetPriceSourceById(int Id);
        void CreatePriceSource(PriceSource priceSource);
    }
}
