using StockPriceMonitor.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Controllers.Tests.MockData
{
    public class PriceSourceMockData
    {
        public static List<PriceSource> GetAllPriceSources()
        {
            return new List<PriceSource>
            {
                new PriceSource() { Id = 1, Name = "Source 1", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1) },
                new PriceSource() { Id = 2, Name = "Source 2", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2) },
                new PriceSource() { Id = 3, Name = "Source 3", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3) },
                new PriceSource() { Id = 4, Name = "Source 4", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4) },
                new PriceSource() { Id = 5, Name = "Source 5", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5) },
                new PriceSource() { Id = 6, Name = "Source 6", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6) },
                new PriceSource() { Id = 7, Name = "Source 7", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(7), UpdatedBy = "System 2", DateLastUpdated = DateTime.Now.AddMinutes(8) }
            };
        }

        public static List<PriceSource> GetZeroPriceSources()
        {
            return new List<PriceSource>();
        }

        public static List<PriceSource> GetAllPriceSourcesIncludingTickers()
        {
            var instance = new List<Ticker>();

            var source1TickerList = new List<Ticker>
            {
                new Ticker() { Id = 1, TickerName = "Ticker 1", PriceSourceId = 1, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1) },
                new Ticker() { Id = 2, TickerName = "Ticker 2", PriceSourceId = 1, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2) },
            };

            var source5TickerList = new List<Ticker>
            {
                new Ticker() { Id = 3, TickerName = "Ticker 3", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3) },
                new Ticker() { Id = 4, TickerName = "Ticker 4", PriceSourceId = 5, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4) },
            };

            var source6TickerList = new List<Ticker>
            {
                new Ticker() { Id = 5, TickerName = "Ticker 5", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5) },
                new Ticker() { Id = 6, TickerName = "Ticker 6", PriceSourceId = 6, IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6) }
            };


            return new List<PriceSource>
            {
                new PriceSource() { Id = 1, Name = "Source 1", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(1), Tickers = source1TickerList },
                new PriceSource() { Id = 2, Name = "Source 2", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(2), Tickers = instance },
                new PriceSource() { Id = 3, Name = "Source 3", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(3), Tickers = instance },
                new PriceSource() { Id = 4, Name = "Source 4", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(4), Tickers = instance },
                new PriceSource() { Id = 5, Name = "Source 5", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(5), Tickers = source5TickerList },
                new PriceSource() { Id = 6, Name = "Source 6", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(6), Tickers = source6TickerList },
                new PriceSource() { Id = 7, Name = "Source 7", IsDeleted = false, CreatedBy = "System", DateCreated = DateTime.Now.AddMinutes(7), UpdatedBy = "System 2", DateLastUpdated = DateTime.Now.AddMinutes(8), Tickers = instance }
            };
        }
        public static List<PriceSource> GetZeroPriceSourcesIncludingTickers()
        {
            return new List<PriceSource>();
        }

        public static List<PriceSource> GetNullPriceSourcesIncludingTickers()
        {
            return null;
        }

    }
}
