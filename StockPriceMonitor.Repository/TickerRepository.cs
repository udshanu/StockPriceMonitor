using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Repository
{
    public class TickerRepository : ITickerRepository
    {
        private readonly AppDbContext _context;

        public TickerRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create ticker.
        /// </summary>
        /// <param name="ticker">Ticker information</param>
        public void CreateTicker(Ticker ticker)
        {
            try
            {
                if (ticker == null)
                {
                    throw new ArgumentNullException(nameof(ticker));
                }

                _context.Tickers.Add(ticker);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateTicker functionality. {ex.Message}");
            }
        }

        /// <summary>
        /// Get ticker by id
        /// </summary>
        /// <param name="Id">Ticker id</param>
        /// <returns>Ticker object</returns>
        public Ticker GetTickerById(int Id)
        {
            try
            {
                return _context.Tickers.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetTickerById functionality. {ex.Message}");
            }
        }
    }
}
