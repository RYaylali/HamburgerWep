using AutoMapper;
using SignalR.DtoLayer.FeatureDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class FeatureMapping :Profile
	{
        public FeatureMapping()
        {
            CreateMap<Feature,CreateFeatureDto>().ReverseMap();
            CreateMap<Feature,UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature,GetFeatureDto>().ReverseMap();
            CreateMap<Feature,ResultFeatureDto>().ReverseMap();
        }
    }
}
