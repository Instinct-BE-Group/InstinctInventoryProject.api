using AutoMapper;
using InstinctInventoryProject.Domain.Models;
using InstinctInventoryProject.Domain.Dtos;
using InstinctInventoryProject.Domain.Dtos.Product;

namespace InstinctInventoryProject.api.Extentions
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, CreateProductDto>();
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, UpdateProductDto>();
            CreateMap<UpdateProductDto, Product>();

        }
    }
}
