using AutoMapper;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockPriceMonitor.Api.Profiles
{
    public class StockPriceProfile : Profile
    {
        public StockPriceProfile()
        {
            // Source --> Target
            CreateMap<StockPrice, StockPriceResponseDTO>();
            CreateMap<StockPriceRequestDTO, StockPrice>();
        }
    }
}
