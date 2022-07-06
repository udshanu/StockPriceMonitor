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
    public class PriceSourceControllerTests
    {
        private Mock<IPriceSourceRepository> _priceSourceRepo;
        private Mock<IMapper> _mapperCommon;

        public PriceSourceControllerTests()
        {
            _priceSourceRepo = new Mock<IPriceSourceRepository>();
            _mapperCommon = new Mock<IMapper>();
        }

        #region GetAllPriceSourcesAndAllRelatedTickers

        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_Returning200StatusCode()
        {
            //Arrange
            _priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetAllPriceSourcesIncludingTickers());

            var systemUnderTest = new PriceSourceController(_priceSourceRepo.Object, _mapperCommon.Object);


            //Act
            var result = systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers();
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
        }

        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_Returning200StatusCodeAndZeroDataCount()
        {
            //Arrange
            _priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetZeroPriceSourcesIncludingTickers());

            var systemUnderTest = new PriceSourceController(_priceSourceRepo.Object, _mapperCommon.Object);


            //Act
            var result = systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers();
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
            Assert.Equal(PriceSourceMockData.GetZeroPriceSourcesIncludingTickers().Count(), modelInfo.Data);
        }

        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_ReturningNullReferenceException()
        {
            //Arrange
            _priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetNullPriceSourcesIncludingTickers());

            var systemUnderTest = new PriceSourceController(_priceSourceRepo.Object, _mapperCommon.Object);


            //Act
            var ex = Record.Exception(() => systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers());


            //Assert
            Assert.NotNull(ex);
            Assert.IsType<ApplicationException>(ex);
            Assert.Equal("Returned PriceSource list is null.", ex.Message);
        }

        #endregion

        #region CreatePriceSource

        [Fact]
        public void CreatePriceSource_ReturningSuccessMessageAnd200StatusCode()
        {
            //Arrange
            var mappingProfile = new PriceSourceProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            _priceSourceRepo.Setup(x => x.CreatePriceSource(PriceSourceMockData.CreatePriceSource())).Returns(true);

            var requestedPriceSource = PriceSourceMockData.GetRequestedPriceSource();

            var systemUnderTest = new PriceSourceController(_priceSourceRepo.Object, _mapper);


            //Act
            var result = systemUnderTest.CreatePriceSource(requestedPriceSource);
            var modelInfo = result.Value as SuccessResponseMessage;


            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.Equal(200, modelInfo.ResponseCode);
            Assert.Equal("Price source successfully created.", modelInfo.Message);
        }

        [Fact]
        public void CreatePriceSource_ReturningNullReferenceException()
        {
            //Arrange
            var mappingProfile = new PriceSourceProfile();
            var config = new MapperConfiguration(mappingProfile);
            var _mapper = new Mapper(config);

            var systemUnderTest = new PriceSourceController(_priceSourceRepo.Object, _mapper);


            //Act
            var ex = Record.Exception(() => systemUnderTest.CreatePriceSource(null));


            //Assert
            Assert.NotNull(ex);
            Assert.IsType<ApplicationException>(ex);
            Assert.Equal("PriceSourceRequestDTO object is null", ex.Message);
        }

        #endregion

    }
}
