using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Interfaces;
using System;

namespace StockPriceMonitor.Repository
{
    public class TickerRepository : ITickerRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public TickerRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create ticker.
        /// </summary>
        /// <param name="ticker">Ticker information</param>
        /// <returns>boolean value</returns>
        public bool CreateTicker(Ticker ticker)
        {
            try
            {
                _context.Tickers.Add(ticker);
                return _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateTicker functionality. {ex.Message}");
            }
        }
    }
}
