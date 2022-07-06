using AutoMapper;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;

namespace StockPriceMonitor.Api.Profiles
{
    public class TickerProfile : MapperConfigurationExpression
    {
        public TickerProfile()
        {
            // Source --> Target
            CreateMap<Ticker, TickerResponseDTO>();
            CreateMap<TickerRequestDTO, Ticker>();
        }
    }
}
