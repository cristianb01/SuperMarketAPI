using AutoMapper;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveCategoryResource, Category>();
            CreateMap<SaveProductResource, Product>();
            CreateMap<CategoryResource, Category>();
        }
    }
}
