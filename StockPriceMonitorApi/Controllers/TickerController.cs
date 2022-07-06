using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockPriceMonitor.Api.ResponseResultMessage;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using StockPriceMonitor.Repository.Interfaces;
using System;

namespace StockPriceMonitor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TickerController : ControllerBase
    {
        private ITickerRepository _tickerRepo;
        private readonly IMapper _mapper;

        public TickerController(ITickerRepository tickerRepo, IMapper mapper)
        {
            _tickerRepo = tickerRepo;
            _mapper = mapper;
        }

        [HttpPost]
        public JsonResult CreateTicker(TickerRequestDTO tickerRequestDto)
        {
            try
            {
                if (tickerRequestDto == null)
                {
                    throw new NullReferenceException("TickerRequestDTO object is null");
                }

                var tickerModel = _mapper.Map<Ticker>(tickerRequestDto);
                tickerModel.CreatedBy = "System";
                tickerModel.DateCreated = DateTime.Now;

                _tickerRepo.CreateTicker(tickerModel);

                return new JsonResult(new SuccessResponseMessage { Message = "Tickers successfully created." });
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
