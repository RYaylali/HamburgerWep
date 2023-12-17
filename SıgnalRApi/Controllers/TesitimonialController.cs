using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.TestiMonialDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TesitimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TesitimonialController(ITestimonialService discountService, IMapper mapper)
		{
			_testimonialService = discountService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateTestimonial(CreateTestimonialDto model)
		{
			_testimonialService.TAdd(new Testimonial()
			{
				Comment = model.Comment,
				ImageUrl = model.ImageUrl,
				Name = model.Name,
				Status = true,
				Title = model.Title

			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteTestimonial(int id)
		{
			_testimonialService.TDelete(_testimonialService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateTestimonial(UpdateTestimonialDto model)
		{
			Testimonial contact = new Testimonial()
			{
				TestimonialID=model.TestimonialID,
				Comment = model.Comment,
				ImageUrl = model.ImageUrl,
				Name = model.Name,
				Status = true,
				Title = model.Title
			};
			_testimonialService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetTestimonial")]
		public IActionResult GetTestimonial(int id)
		{
			return Ok(_testimonialService.TGetById(id));
		}
	}
}
