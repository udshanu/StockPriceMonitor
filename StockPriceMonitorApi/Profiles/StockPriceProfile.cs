using AutoMapper;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;

namespace StockPriceMonitor.Api.Profiles
{
    public class StockPriceProfile : MapperConfigurationExpression
    {
        public StockPriceProfile()
        {
            // Source --> Target
            CreateMap<StockPrice, StockPriceResponseDTO>();
            CreateMap<StockPriceRequestDTO, StockPrice>();
        }
    }
}
