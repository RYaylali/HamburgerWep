using AutoMapper;
using SignalR.DtoLayer.DiscountDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class DiscountMapping : Profile
	{
        public DiscountMapping()
        {
            CreateMap<Discount,GetDiscountDto>().ReverseMap();
            CreateMap<Discount,CreateDiscountDto>().ReverseMap();
            CreateMap<Discount,UpdateDiscountDto>().ReverseMap();
            CreateMap<Discount,ResultDiscountDto>().ReverseMap();
        }
    }
}
