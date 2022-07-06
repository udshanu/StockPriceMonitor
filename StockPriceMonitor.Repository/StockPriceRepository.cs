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
    public class StockPriceRepository : IStockPriceRepository
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public StockPriceRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create stock price
        /// </summary>
        /// <param name="stockPrice">Stock price information</param>
        public bool CreateStockPrice(StockPrice stockPrice)
        {
            try
            {
                _context.StockPrices.Add(stockPrice);
                return _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateStockPrice functionality. {ex.Message}");
            }
        }

        /// <summary>
        /// Get last five stock prices
        /// </summary>
        /// <param name="tickerId">Ticker Id</param>
        /// <returns>List of stock prices</returns>
        public IEnumerable<StockPrice> GetLastFiveStockPrices(int tickerId)
        {
            try
            {
                return _context.StockPrices.Where(x => x.TickerId == tickerId).AsEnumerable().TakeLast(5).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetLastFiveStockPrices functionality. {ex.Message}");
            }
        }
    }
}
