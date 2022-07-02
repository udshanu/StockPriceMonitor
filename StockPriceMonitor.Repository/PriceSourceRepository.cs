using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPriceMonitor.Repository
{
    public class PriceSourceRepository : IPriceSourceRepository
    {
        private readonly AppDbContext _context;

        public PriceSourceRepository(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create price source.
        /// </summary>
        /// <param name="priceSource">Price source information</param>
        public void CreatePriceSource(PriceSource priceSource)
        {
            try
            {
                if (priceSource == null)
                {
                    throw new ArgumentNullException(nameof(priceSource));
                }

                _context.PriceSources.Add(priceSource);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreatePriceSource functionality. {ex.Message}");
            }
        }

        /// <summary>
        /// Get all price sources
        /// </summary>
        /// <returns>List of price sources</returns>
        public IEnumerable<PriceSource> GetAllPriceSources()
        {
            try
            {
                return _context.PriceSources.ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetAllPriceSources functionality. {ex.Message}");
            }
        }

        /// <summary>
        /// Get price source using id.
        /// </summary>
        /// <param name="Id">Price source id</param>
        /// <returns>Price source object</returns>
        public PriceSource GetPriceSourceById(int Id)
        {
            try
            {
                return _context.PriceSources.FirstOrDefault(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetPriceSourceById functionality. {ex.Message}");
            }
        }


    }
}
