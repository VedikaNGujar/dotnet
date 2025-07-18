﻿using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Helpers
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mapperConfiguration = new MapperConfiguration(
                config =>
                    {
                        config.CreateMap<ProductDto, Product>();
                        config.CreateMap<Product, ProductDto>();
                    }
                );
            return mapperConfiguration;
        }
    }
}
