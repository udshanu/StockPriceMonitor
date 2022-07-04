using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository.Tests.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockPriceMonitor.Repository.Tests
{

    public class PriceSourceRepositoryTests : IDisposable
    {
        private readonly AppDbContext _dbContext;
        public PriceSourceRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
            _dbContext = new AppDbContext(options);
            _dbContext.Database.EnsureCreated();
        }

        [Fact]
        public void GetAllPriceSourcesIncludingTickers_ReturnPriceSourcesCollection()
        {
            //Arrange
            _dbContext.PriceSources.AddRange(PriceSourceMockData.GetAllPriceSourcesIncludingTickers());
            _dbContext.SaveChanges();

            var systemUnderTest = new PriceSourceRepository(_dbContext);

            //Act
            var result = systemUnderTest.GetAllPriceSourcesIncludingTickers();


            //Assert
            result.Should().HaveCount(PriceSourceMockData.GetAllPriceSourcesIncludingTickers().Count);

        }

        public void Dispose()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Dispose();
        }


    }
}
