using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using StockPriceMonitor.Api.Controllers;
using StockPriceMonitor.Api.Profiles;
using StockPriceMonitor.Api.ResponseResultMessage;
using StockPriceMonitor.Controllers.Tests.MockData;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Linq;
using Xunit;

namespace StockPriceMonitor.Controllers.Tests
{
    public class StockPriceControllerTests
    {
        private Mock<IStockPriceRepository> _stockPriceRepo;
        private Mock<IMapper> _mapperCommon;

        public StockPriceControllerTests()
        {
            _stockPriceRepo = new Mock<IStockPriceRepository>();
            _mapperCommon = new Mock<IMapper>();
        }

        #region GetLastFiveStockPrices

        [Fact]
        public void GetLastFiveStockPrices_Returning200StatusCode()
        {
            //Arrange
            int id = 2;
            _stockPriceRepo.Setup(x => x.GetLastFiveStockPrices(id)).Returns(StockPriceMockData.GetLastFiveStockPrices());

            var systemUnderTest = new StockPriceController(_stockPriceRepo.Object, _mapperCommon.Object);


            //Act
            var result = systemUnderTest.GetLastFiveStockPrices(id);
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
        }

        [Fact]
        public void GetLastFiveStockPrices_Returning200StatusCodeAndZeroDataCount()
        {
            //Arrange
            int id = 2;
            _stockPriceRepo.Setup(x => x.GetLastFiveStockPrices(id)).Returns(StockPriceMockData.GetZeroLastFiveStockPrices());

            var systemUnderTest = new StockPriceController(_stockPriceRepo.Object, _mapperCommon.Object);


            //Act
            var result = systemUnderTest.GetLastFiveStockPrices(id);
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
            Assert.Equal(StockPriceMockData.GetZeroLastFiveStockPrices().Count(), modelInfo.Data.Count);
        }

        [Fact]
        public void GetLastFiveStockPrices_ReturningNullReferenceException()
        {
            //Arrange
            int id = 2;
            _stockPriceRepo.Setup(x => x.GetLastFiveStockPrices(id)).Returns(StockPriceMockData.GetNullLastFiveStockPrices());

            var systemUnderTest = new StockPriceController(_stockPriceRepo.Object, _mapperCommon.Object);


            //Act
            var ex = Record.Exception(() => systemUnderTest.GetLastFiveStockPrices(id));


            //Assert
            Assert.NotNull(ex);
            Assert.IsType<ApplicationException>(ex);
            Assert.Equal("Returned StockPrice list is null.", ex.Message);
        }

        #endregion

        #region CreateStockPrice

        [Fact]
        public void CreateStockPrice_ReturningSuccessMessageAnd200StatusCode()
        {
            //Arrange
            var mappingProfile = new StockPriceProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            _stockPriceRepo.Setup(x => x.CreateStockPrice(StockPriceMockData.CreateStockPrice())).Returns(true);

            var requestedStockPrice = StockPriceMockData.GetRequestedStockPrice();

            var systemUnderTest = new StockPriceController(_stockPriceRepo.Object, _mapper);


            //Act
            var result = systemUnderTest.CreateStockPrice(requestedStockPrice);
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
            Assert.Equal("Stock price successfully created.", modelInfo.Message);
        }

        [Fact]
        public void CreateStockPrice_ReturningNullReferenceException()
        {
            //Arrange
            var mappingProfile = new StockPriceProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            var systemUnderTest = new StockPriceController(_stockPriceRepo.Object, _mapper);


            //Act
            var ex = Record.Exception(() => systemUnderTest.CreateStockPrice(null));


            //Assert
            Assert.NotNull(ex);
            Assert.IsType<ApplicationException>(ex);
            Assert.Equal("StockPriceRequestDTO object is null", ex.Message);
        }

        #endregion


    }
}
