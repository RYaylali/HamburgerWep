using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}
		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetListAll();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateBooking(CreateBookingDto model)
		{
			Booking booking = new Booking()
			{
				Mail = model.Mail,
				Date = model.Date,
				Name = model.Name,
				PersonCount = model.PersonCount,
				Phone = model.Phone,
			};
			_bookingService.TAdd(booking);
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteBooking(int id)
		{
			_bookingService.TDelete(_bookingService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateBooking(UpdateBookingDto model)
		{
			Booking booking = new Booking()
			{
				BookingID = model.BookingID,
				Mail = model.Mail,
				Date = model.Date,
				Name = model.Name,
				PersonCount = model.PersonCount,
				Phone = model.Phone,
			};
			_bookingService.TUpdate(booking);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetBooking")]
		public IActionResult GetBooking(int id)
		{
			return Ok(_bookingService.TGetById(id));
		}
	}
}
