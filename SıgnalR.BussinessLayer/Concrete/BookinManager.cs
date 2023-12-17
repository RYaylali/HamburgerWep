using SıgnalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SıgnalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SıgnalR.BussinessLayer.Concrete
{
	public class BookinManager : IBookingService
	{
		private readonly IBookingDal _bookingDal;

		public BookinManager(IBookingDal bookingDal)
		{
			_bookingDal = bookingDal;
		}

		public void TAdd(Booking entity)
		{
			_bookingDal.Add(entity);
		}

		public void TDelete(Booking entity)
		{
			_bookingDal.Delete(entity);
		}

		public Booking TGetById(int id)
		{
			return _bookingDal.GetById(id);
		}

		public List<Booking> TGetListAll()
		{
			return _bookingDal.GetListAll();
		}

		public void TUpdate(Booking entity)
		{
			_bookingDal.Update(entity);
		}
	}
}
