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
    public class TickerController : ControllerBase
    {
        private ITickerRepository _tickerRepo;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public TickerController(ITickerRepository tickerRepo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _tickerRepo = tickerRepo;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TickerResponseDTO>> GetAllTickers()
        {
            try
            {
                var tickerList = _tickerRepo.GetAllTickers().OrderBy(x => x.TickerName);

                return Ok(_mapper.Map<IEnumerable<TickerResponseDTO>>(tickerList));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on GetAllTickers functionality in the TickerController. {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetTickerById")]
        public ActionResult<TickerResponseDTO> GetTickerById(int id)
        {
            try
            {
                var tickerItem = _tickerRepo.GetTickerById(id);

                if (tickerItem != null)
                {
                    return Ok(_mapper.Map<TickerResponseDTO>(tickerItem));
                }

                return NotFound();

            }
            catch (Exception ex)
            {

                throw new ApplicationException($"Exception on GetTickerById functionality in the TickerController. {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<TickerResponseDTO> CreateTicker(TickerRequestDTO tickerRequestDto)
        {
            try
            {
                var tickerModel = _mapper.Map<Ticker>(tickerRequestDto);
                tickerModel.CreatedBy = "System";
                tickerModel.DateCreated = DateTime.Now;

                _tickerRepo.CreateTicker(tickerModel);
                _unitOfWork.SaveChanges();

                var tickerResponseDto = _mapper.Map<TickerResponseDTO>(tickerModel);

                return CreatedAtRoute(nameof(GetTickerById), new { Id = tickerResponseDto.Id }, tickerResponseDto);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Exception on CreateTicker functionality in the TickerController. {ex.Message}");
            }
        }
    }
}
