using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.AboultDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutController : ControllerBase
	{
		private readonly IAboutService _aboutService;

		public AboutController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}
		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _aboutService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateAbout(CreateAboutDto model)
		{
			About about = new About
			{
				Title = model.Title,
				ImageURL=model.ImageURL,
				Description= model.Description
			
			};
			_aboutService.TAdd(about);
			return Ok("Hakkımda Kısmı Başarılı Bir Şekilde Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteAbout(int id)
		{
			var values = _aboutService.TGetById(id);
			_aboutService.TDelete(values);
			return Ok("Hakkımda silindi");
		}
		[HttpPut]
		public IActionResult UpdateAbout(UpdateAboutDto model)
		{
			About about = new About
			{
				AboutID= model.AboutID,
				Title = model.Title,
				ImageURL = model.ImageURL,
				Description = model.Description

			};
			_aboutService.TUpdate(about);
			return Ok("Hakkımda güncellendi");
		}
		[HttpGet("GetAbout")]
		public IActionResult GetAbout(int id)
		{
			var values = _aboutService.TGetById(id);
			return Ok(values);
		}
	}
}
