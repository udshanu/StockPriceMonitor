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

        public StockPriceRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create stock price
        /// </summary>
        /// <param name="stockPrice">Stock price information</param>
        public void CreateStockPrice(StockPrice stockPrice)
        {
            try
            {
                if (stockPrice == null)
                {
                    throw new ArgumentNullException(nameof(stockPrice));
                }

                _context.StockPrices.Add(stockPrice);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateStockPrice functionality. {ex.Message}");
            }
        }

        ///// <summary>
        ///// Get all stock prices
        ///// </summary>
        ///// <returns>List of stock prices</returns>
        //public IEnumerable<StockPrice> GetAllStockPrices()
        //{
        //    try
        //    {
        //        return _context.StockPrices.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException($"Exception on GetAllStockPrices functionality. {ex.Message}");
        //    }
        //}

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

        /// <summary>
        /// Get stock price using id
        /// </summary>
        /// <param name="Id">Stock price id</param>
        /// <returns>Stock price object</returns>
        public StockPrice GetStockPriceById(int Id)
        {
            try
            {
                return _context.StockPrices.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetStockPriceById functionality. {ex.Message}");
            }
        }
    }
}
