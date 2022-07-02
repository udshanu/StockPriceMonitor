﻿using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Save changes to the database.
        /// </summary>
        /// <returns>true or false valeu</returns>
        public bool SaveChanges()
        {
            try
            {
                return (_context.SaveChanges() >= 0);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on SaveChanges functionality. {ex.Message}");
            }
        }
    }
}
