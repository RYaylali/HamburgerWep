using AutoMapper;
using SignalR.DtoLayer.ProductDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class ProductMapping :Profile
	{
        public ProductMapping()
        {
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
        }
    }
}
