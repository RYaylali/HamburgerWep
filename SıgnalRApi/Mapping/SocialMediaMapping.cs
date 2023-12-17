using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class SocialMediaMapping :Profile
	{
        public SocialMediaMapping()
        {
            CreateMap<CreateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<GetSocialMediaDto, SocialMedia>().ReverseMap();
            CreateMap<ResultSocialMediaDto, SocialMedia>().ReverseMap();
        }
    }
}
