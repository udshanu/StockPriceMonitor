using AutoMapper;
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
    public class PriceSourceController : ControllerBase
    {
        private IPriceSourceRepository _priceSourceRepo;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PriceSourceController(IPriceSourceRepository priceSourceRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _priceSourceRepo = priceSourceRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<PriceSourceResponseDTO>> GetAllPriceSources()
        //{
        //    try
        //    {
        //        var priceSourceList = _priceSourceRepo.GetAllPriceSources().OrderBy(x => x.Name).ToList();

        //        return Ok(_mapper.Map<IEnumerable<PriceSourceResponseDTO>>(priceSourceList));
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApplicationException($"Exception on GetAllPriceSources functionality in the PriceSourceController. {ex.Message}");
        //    }
        //}

        [Route("GetAllPriceSourcesAndAllRelatedTickers")]
        [HttpGet]
        public ActionResult GetAllPriceSourcesAndAllRelatedTickers()
        {
            try
            {
                var priceSourceList = _priceSourceRepo.GetAllPriceSourcesIncludingTickers();
                var filteredPriceSourceList = priceSourceList.Where(x => x.Tickers.Any()).OrderBy(x => x.Name).ToList();
                var filteredTickerList = priceSourceList.SelectMany(x => x.Tickers).Distinct().OrderBy(x => x.TickerName).ToList();

                var mappedPiceSourceResult = _mapper.Map<IEnumerable<PriceSourceResponseDTO>>(filteredPriceSourceList);
                var mappedTickerResult = _mapper.Map<IEnumerable<TickerResponseDTO>>(filteredTickerList);

                return Ok(new { PriceSourceList = mappedPiceSourceResult, TickerList = mappedTickerResult });
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetAllPriceSourcesAndAllRelatedTickers functionality in the PriceSourceController. {ex.Message}");
            }
        }



        [HttpGet("{id}", Name = "GetPriceSourceById")]
        public ActionResult<PriceSourceResponseDTO> GetPriceSourceById(int id)
        {
            try
            {
                var priceSourceItem = _priceSourceRepo.GetPriceSourceById(id);

                if (priceSourceItem != null)
                {
                    return Ok(_mapper.Map<PriceSourceResponseDTO>(priceSourceItem));
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Exception on GetPriceSourceById functionality in the PriceSourceController. {ex.Message}");
            }
        }

        [Route("CreatePriceSource")]
        [HttpPost]
        public ActionResult<PriceSourceResponseDTO> CreatePriceSource(PriceSourceRequestDTO priceSourceRequestDto)
        {
            try
            {
                var priceSourceModel = _mapper.Map<PriceSource>(priceSourceRequestDto);
                priceSourceModel.CreatedBy = "System";
                priceSourceModel.DateCreated = DateTime.Now;

                _priceSourceRepo.CreatePriceSource(priceSourceModel);
                _unitOfWork.SaveChanges();

                var priceSourceResponseDto = _mapper.Map<PriceSourceResponseDTO>(priceSourceModel);

                return CreatedAtRoute(nameof(GetPriceSourceById), new { Id = priceSourceResponseDto.Id }, priceSourceResponseDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreatePriceSource functionality in the PriceSourceController. {ex.Message}");
            }
        }
    }
}
