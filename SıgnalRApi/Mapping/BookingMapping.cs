using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SıgnalR.EntityLayer.Entities;

namespace SıgnalRApi.Mapping
{
	public class BookingMapping :Profile
	{
        public BookingMapping()
        {
            CreateMap<Booking, CreateBookingDto>().ReverseMap();
            CreateMap<Booking, UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();
            CreateMap<Booking, ResultBookingDto>().ReverseMap();
        }
    }
}
