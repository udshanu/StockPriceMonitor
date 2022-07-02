using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Interfaces;
using System;

namespace StockPriceMonitor.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
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
