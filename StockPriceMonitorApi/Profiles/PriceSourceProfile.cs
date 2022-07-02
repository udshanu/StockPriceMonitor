﻿using AutoMapper;
using StockPriceMonitor.Common.DataTransferObjects;
using StockPriceMonitor.Entities.Models;

namespace StockPriceMonitor.Api.Profiles
{
    public class PriceSourceProfile : Profile
    {
        public PriceSourceProfile()
        {
            // Source --> Target
            CreateMap<PriceSource, PriceSourceResponseDTO>();
            CreateMap<PriceSourceRequestDTO, PriceSource>();
        }
    }
}
