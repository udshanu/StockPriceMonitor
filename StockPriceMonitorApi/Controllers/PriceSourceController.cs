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

        public PriceSourceController(IPriceSourceRepository priceSourceRepo, IMapper mapper)
        {
            _priceSourceRepo = priceSourceRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PriceSourceResponseDTO>> GetAllPriceSources()
        {
            try
            {
                Console.WriteLine("--> Geting all the price sources...");

                var priceSourceList = _priceSourceRepo.GetAllPriceSources();

                return Ok(_mapper.Map<IEnumerable<PriceSourceResponseDTO>>(priceSourceList));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetAllPriceSources functionality in the PriceSourceController. {ex.Message}");
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

        [HttpPost]
        public ActionResult<PriceSourceResponseDTO> CreatePriceSource(PriceSourceRequestDTO priceSourceRequestDto)
        {
            try
            {
                var priceSourceModel = _mapper.Map<PriceSource>(priceSourceRequestDto);
                _priceSourceRepo.CreatePriceSource(priceSourceModel);
                _priceSourceRepo.SaveChanges();

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
