using AutoMapper;
using ShopWarehouse.API.Data.Dto.Product;
using ShopWarehouse.API.Data.Models;

namespace ShopWarehouse.API.Core.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
