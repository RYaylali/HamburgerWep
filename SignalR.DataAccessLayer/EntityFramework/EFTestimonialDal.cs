﻿using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SıgnalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EFTestimonialDal : GenericRepository<Testimonial>, ITestimonialDal
	{
		public EFTestimonialDal(SignalRContext context) : base(context)
		{
		}
	}
}
