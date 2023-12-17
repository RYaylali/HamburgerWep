using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SıgnalR.BussinessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using SignalR.DtoLayer.CategoryDto;
using SignalR.DtoLayer.ContactDto;

namespace SıgnalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CreateContact(CreateContactDto model)
		{
			_contactService.TAdd(new Contact()
			{
				FooterDescription = model.FooterDescription,
				Location = model.Location,
				Mail = model.Mail,
				Phone = model.Phone,
			});
			return Ok("Başarıyla Eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteContact(int id)
		{
			_contactService.TDelete(_contactService.TGetById(id));
			return Ok("Başarıyla Silindi");
		}
		[HttpPut]
		public IActionResult UpdateContact(UpdateContactDto model)
		{
			Contact contact = new Contact()
			{
				FooterDescription = model.FooterDescription,
				Location = model.Location,
				Mail = model.Mail,
				Phone = model.Phone,
			};
			_contactService.TUpdate(contact);
			return Ok("Başarıyla Güncellendi");
		}
		[HttpGet("GetContact")]
		public IActionResult GetContact(int id)
		{
			return Ok(_contactService.TGetById(id));
		}
	}
}
