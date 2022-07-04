﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPriceMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {
        private readonly IStockPriceRepository _stockPriceRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public StockPriceController(IStockPriceRepository stockPriceRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _stockPriceRepo = stockPriceRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}", Name = "GetStockPriceById")]
        public ActionResult<StockPriceResponseDTO> GetStockPriceById(int id)
        {
            try
            {
                var stockPriceItem = _stockPriceRepo.GetStockPriceById(id);

                if (stockPriceItem != null)
                {
                    return Ok(_mapper.Map<StockPriceResponseDTO>(stockPriceItem));
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Exception on GetStockPriceById functionality in the StockPriceController. {ex.Message}");
            }
        }

        [Route("CreateStockPrice")]
        [HttpPost]
        public ActionResult<StockPriceResponseDTO> CreateStockPrice(StockPriceRequestDTO stockPriceRequestDto)
        {
            try
            {
                var stockPriceModel = _mapper.Map<StockPrice>(stockPriceRequestDto);
                stockPriceModel.CreatedBy = "System";
                stockPriceModel.DateCreated = DateTime.Now;

                _stockPriceRepo.CreateStockPrice(stockPriceModel);
                _unitOfWork.SaveChanges();

                var stockPriceResponseDto = _mapper.Map<StockPriceResponseDTO>(stockPriceModel);

                return CreatedAtRoute(nameof(GetStockPriceById), new { Id = stockPriceResponseDto.Id }, stockPriceResponseDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateStockPrice functionality in the StockPriceController. {ex.Message}");
            }
        }
        [Route("GetLastFiveStockPrices/{id}")]
        [HttpGet()]
        public ActionResult<IEnumerable<LastFiveStockPriceResponseDTO>> GetLastFiveStockPrices(int id)
        {
            try
            {
                var stockPriceList = _stockPriceRepo.GetLastFiveStockPrices(id);

                var formatedList = stockPriceList.Select(x => new LastFiveStockPriceResponseDTO { DateTime = (x.DateLastUpdated.HasValue ? x.DateLastUpdated.Value : x.DateCreated).ToString("yyyy-MM-dd HH:mm:ss"), Price = x.Price.ToString("0.00") }).OrderByDescending(x => x.DateTime);

                return Ok(formatedList);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetLastFiveStockPrices functionality in the StockPriceController. {ex.Message}");
            }
        }
    }
}
