using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.DiscountDto;
using SignalR.DtoLayer.SocialMediaDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto model)
		{
			_socialMediaService.TAdd(new SocialMedia()
			{
				Icon = model.Icon,
				SocialMediaTitle = model.SocialMediaTitle,
				Url = model.Url,
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteSocialMedia(int id)
		{
			_socialMediaService.TDelete(_socialMediaService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto model)
		{
			SocialMedia contact = new SocialMedia()
			{
				SocialMediaID=model.SocialMediaID,
				Icon = model.Icon,
				SocialMediaTitle = model.SocialMediaTitle,
				Url = model.Url,
			};
			_socialMediaService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetSocialMedia")]
		public IActionResult GetSocialMedia(int id)
		{
			return Ok(_socialMediaService.TGetById(id));
		}
	}
}
