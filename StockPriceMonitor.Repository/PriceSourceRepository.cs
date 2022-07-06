using Microsoft.EntityFrameworkCore;
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
        private readonly IUnitOfWork _unitOfWork;

        public PriceSourceRepository(AppDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Create price source.
        /// </summary>
        /// <param name="priceSource">Price source information</param>
        public bool CreatePriceSource(PriceSource priceSource)
        {
            try
            {
                _context.PriceSources.Add(priceSource);
                return _unitOfWork.SaveChanges();
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
        public IEnumerable<PriceSource> GetAllPriceSourcesIncludingTickers()
        {
            try
            {
                return _context.PriceSources.Include(x => x.Tickers).ToList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetAllPriceSourcesIncludingTickers functionality. {ex.Message}");
            }
        }
    }
}
