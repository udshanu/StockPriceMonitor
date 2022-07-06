using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockPriceMonitor.Api.Controllers;
using StockPriceMonitor.Api.Profiles;
using StockPriceMonitor.Api.ResponseResultMessage;
using StockPriceMonitor.Controllers.Tests.MockData;
using StockPriceMonitor.Repository.Interfaces;
using System;
using Xunit;

namespace StockPriceMonitor.Controllers.Tests
{
    public class TickerControllerTests
    {
        private Mock<ITickerRepository> _tickersRepo;
        private Mock<IMapper> _mapperCommon;
        public TickerControllerTests()
        {
            _tickersRepo = new Mock<ITickerRepository>();
            _mapperCommon = new Mock<IMapper>();
        }

        [Fact]
        public void CreateTicker_ReturningSuccessMessageAnd200StatusCode()
        {
            //Arrange
            var mappingProfile = new TickerProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            _tickersRepo.Setup(x => x.CreateTicker(TickerMockData.CreateTicker())).Returns(true);

            var requestedTicker = TickerMockData.GetRequestedTicker();

            var systemUnderTest = new TickerController(_tickersRepo.Object, _mapper);


            //Act
            var result = systemUnderTest.CreateTicker(requestedTicker);
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
            Assert.Equal("Tickers successfully created.", modelInfo.Message);
        }

        [Fact]
        public void CreateTicker_ReturningNullReferenceException()
        {
            //Arrange
            var mappingProfile = new TickerProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            var systemUnderTest = new TickerController(_tickersRepo.Object, _mapper);


            //Act
            var ex = Record.Exception(() => systemUnderTest.CreateTicker(null));


            //Assert
            Assert.NotNull(ex);
            Assert.IsType<ApplicationException>(ex);
            Assert.Equal("TickerRequestDTO object is null", ex.Message);
        }
    }
}
