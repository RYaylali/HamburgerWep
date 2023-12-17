using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult DiscountList()
		{
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto model)
		{
			_discountService.TAdd(new Discount()
			{
				Amount = model.Amount,
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Title = model.Title
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteDiscount(int id)
		{
			_discountService.TDelete(_discountService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto model)
		{
			Discount contact = new Discount()
			{
				DiscountID = model.DiscountID,
				Amount = model.Amount,
				Description = model.Description,
				ImageUrl = model.ImageUrl,
				Title = model.Title
			};
			_discountService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetDiscount")]
		public IActionResult GetContact(int id)
		{
			return Ok(_discountService.TGetById(id));
		}
	}
}
