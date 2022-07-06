using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockPriceMonitor.Api.ResponseResultMessage;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Repository.Interfaces;
using System;
using System.Linq;

namespace StockPriceMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockPriceController : ControllerBase
    {
        private readonly IStockPriceRepository _stockPriceRepo;
        private readonly IMapper _mapper;

        public StockPriceController(IStockPriceRepository stockPriceRepo, IMapper mapper)
        {
            _stockPriceRepo = stockPriceRepo;
            _mapper = mapper;
        }

        [Route("CreateStockPrice")]
        [HttpPost]
        public JsonResult CreateStockPrice(StockPriceRequestDTO stockPriceRequestDto)
        {
            try
            {
                if (stockPriceRequestDto == null)
                {
                    throw new NullReferenceException("StockPriceRequestDTO object is null");
                }

                var stockPriceModel = _mapper.Map<StockPrice>(stockPriceRequestDto);
                stockPriceModel.CreatedBy = "System";
                stockPriceModel.DateCreated = DateTime.Now;

                _stockPriceRepo.CreateStockPrice(stockPriceModel);

                return new JsonResult(new SuccessResponseMessage { Message = "Stock price successfully created." });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        [Route("GetLastFiveStockPrices/{id}")]
        [HttpGet()]
        public JsonResult GetLastFiveStockPrices(int id)
        {
            try
            {
                var stockPriceList = _stockPriceRepo.GetLastFiveStockPrices(id);

                if (stockPriceList == null)
                {
                    throw new NullReferenceException("Returned StockPrice list is null.");
                }

                if (stockPriceList.Count() == 0)
                {
                    return new JsonResult(new SuccessResponseMessage { Data = stockPriceList.Count() });
                }

                var formatedList = stockPriceList.Select(x => new LastFiveStockPriceResponseDTO { DateTime = (x.DateLastUpdated.HasValue ? x.DateLastUpdated.Value : x.DateCreated).ToString("yyyy-MM-dd HH:mm:ss"), Price = x.Price.ToString("0.00") }).OrderByDescending(x => x.DateTime).ToList();

                //return Ok(formatedList);

                return new JsonResult(new SuccessResponseMessage { Data = formatedList });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
