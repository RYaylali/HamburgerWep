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
	public class AboutManager : IAboutService
	{
		private readonly IAboutDal _aboutDal;

		public AboutManager(IAboutDal aboutDal)//Dependecy Injection
		{
			_aboutDal = aboutDal;
		}

		public void TAdd(About entity)
		{
			_aboutDal.Add(entity);
		}

		public void TDelete(About entity)
		{
			_aboutDal.Delete(entity);
		}

		public About TGetById(int id)
		{
			return _aboutDal.GetById(id);
		}

		public List<About> TGetListAll()
		{
			return _aboutDal.GetListAll();
		}

		public void TUpdate(About entity)
		{
			_aboutDal.Update(entity);
		}
	}
}
