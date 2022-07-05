using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockPriceMonitor.Api.ResponseResultMessage;
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
    public class PriceSourceController : ControllerBase
    {
        private IPriceSourceRepository _priceSourceRepo;
        private readonly IMapper _mapper;

        public PriceSourceController(IPriceSourceRepository priceSourceRepo, IMapper mapper)
        {
            _priceSourceRepo = priceSourceRepo;
            _mapper = mapper;
        }

        [Route("GetAllPriceSourcesAndAllRelatedTickers")]
        [HttpGet]
        public JsonResult GetAllPriceSourcesAndAllRelatedTickers()
        {
            try
            {
                var priceSourceList = _priceSourceRepo.GetAllPriceSourcesIncludingTickers();

                if (priceSourceList == null)
                {
                    throw new NullReferenceException("Returned PriceSource list is null.");
                }

                if (priceSourceList.Count() == 0)
                {
                    return new JsonResult(new SuccessResponseMessage { Data = priceSourceList.Count() });
                }

                var filteredPriceSourceList = priceSourceList.Where(x => x.Tickers.Any()).OrderBy(x => x.Name).ToList();
                var filteredTickerList = priceSourceList.SelectMany(x => x.Tickers).Distinct().OrderBy(x => x.TickerName).ToList();

                var mappedPiceSourceResult = _mapper.Map<IEnumerable<PriceSourceResponseDTO>>(filteredPriceSourceList);
                var mappedTickerResult = _mapper.Map<IEnumerable<TickerResponseDTO>>(filteredTickerList);

                return new JsonResult(new SuccessResponseMessage { Data = new { PriceSourceList = mappedPiceSourceResult, TickerList = mappedTickerResult } });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        [Route("CreatePriceSource")]
        [HttpPost]
        public JsonResult CreatePriceSource(PriceSourceRequestDTO priceSourceRequestDto)
        {
            try
            {

                if (priceSourceRequestDto == null)
                {
                    throw new NullReferenceException("PriceSourceRequestDTO object is null");
                }


                var priceSourceModel = _mapper.Map<PriceSource>(priceSourceRequestDto);
                priceSourceModel.CreatedBy = "System";
                priceSourceModel.DateCreated = DateTime.Now;

                _priceSourceRepo.CreatePriceSource(priceSourceModel);

                return new JsonResult(new SuccessResponseMessage { Message = "Price source successfully created." });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
