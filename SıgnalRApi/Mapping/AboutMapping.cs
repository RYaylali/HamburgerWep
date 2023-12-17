using AutoMapper;
using SignalR.DtoLayer.AboultDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class AboutMapping : Profile
	{
        public AboutMapping()
        {
            CreateMap<About,ResultAboutDto>().ReverseMap();
            CreateMap<About,CreateAboutDto>().ReverseMap();
            CreateMap<About,GetAboutDto>().ReverseMap();
            CreateMap<About,UpdateAboutDto>().ReverseMap();
        }
    }
}
