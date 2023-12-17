using AutoMapper;
using SignalR.DtoLayer.ContactDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class ContactMapping : Profile
	{
		public ContactMapping()
		{
			CreateMap<Contact, CreateContactDto>().ReverseMap();
			CreateMap<Contact, GetContactDto>().ReverseMap();
			CreateMap<Contact, UpdateContactDto>().ReverseMap();
			CreateMap<Contact, ResultContactDto>().ReverseMap();

		}
	}
}
