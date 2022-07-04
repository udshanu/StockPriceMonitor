﻿using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using StockPriceMonitor.Api.Controllers;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Controllers.Tests.MockData;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Entities.Models.DataContext;
using StockPriceMonitor.Repository;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StockPriceMonitor.Controllers.Tests
{
    public class PriceSourceControllerTests
    {
        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_ShouldReturn200Status()
        {
            //Arrange
            var priceSourceRepo = new Mock<IPriceSourceRepository>();
            priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetAllPriceSourcesIncludingTickers());

            var mapper = new Mock<IMapper>();

            var systemUnderTest = new PriceSourceController(priceSourceRepo.Object, mapper.Object, new UnitOfWork(new AppDbContext(new DbContextOptions<AppDbContext>())));

            ////Act
            var result = systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers();

            ////Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result as OkObjectResult).StatusCode.Should().Be(200);
        }

        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_NoContentResult()
        {
            //Arrange
            var priceSourceRepo = new Mock<IPriceSourceRepository>();
            priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetZeroPriceSourcesIncludingTickers());

            var mapper = new Mock<IMapper>();

            var systemUnderTest = new PriceSourceController(priceSourceRepo.Object, mapper.Object, new UnitOfWork(new AppDbContext(new DbContextOptions<AppDbContext>())));

            ////Act
            var result = systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers();

            ////Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        [Fact]
        public void GetAllPriceSourcesAndAllRelatedTickers_Null()
        {
            //Arrange
            var priceSourceRepo = new Mock<IPriceSourceRepository>();
            priceSourceRepo.Setup(x => x.GetAllPriceSourcesIncludingTickers()).Returns(PriceSourceMockData.GetNullPriceSourcesIncludingTickers());

            var mapper = new Mock<IMapper>();

            var systemUnderTest = new PriceSourceController(priceSourceRepo.Object, mapper.Object, new UnitOfWork(new AppDbContext(new DbContextOptions<AppDbContext>())));

            ////Act
            var result = systemUnderTest.GetAllPriceSourcesAndAllRelatedTickers();

            ////Assert
            result.GetType().Should().Be(typeof(NotFoundResult));
            (result as NotFoundResult).StatusCode.Should().Be(404);
        }

        [Fact]
        public void CreatePriceSource_ShouldCallCreatePriceSourceOnce()
        {
            //Arrange
            var priceSourceRepo = new Mock<IPriceSourceRepository>();
            var mapper = new Mock<IMapper>();

            priceSourceRepo.Setup(x => x.CreatePriceSource(new PriceSource()));

            var requestedPriceSource = PriceSourceMockData.GetRequestedPriceSource();

            var systemUnderTest = new PriceSourceController(priceSourceRepo.Object, mapper.Object, new UnitOfWork(new AppDbContext(new DbContextOptions<AppDbContext>())));

            //Act
            var result = systemUnderTest.CreatePriceSource(requestedPriceSource);

            ////Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            (result.Result as OkObjectResult).StatusCode.Should().Be(200);
        }
    }
}
