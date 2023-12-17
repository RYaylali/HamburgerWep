using AutoMapper;
using SignalR.DtoLayer.TestiMonialDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class TestimonialMapping : Profile
	{
		public TestimonialMapping()
		{
			CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, GetTestimonialDto>().ReverseMap();
			CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
		}
	}
}
