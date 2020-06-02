using AutoMapper;
using SuperMarketAPI.Extensions;
using SuperMarketAPI.Models;
using SuperMarketAPI.Resources;
using SuperMarketAPI.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperMarketAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Category, CategoryResource>();

            CreateMap<Product, ProductResource>();

            CreateMap<Purchase, PurchaseResource>();

            CreateMap<ProductPurchase, ProductPurchaseResource>();

            CreateMap<User, UserResource>();
        }
    }
}
