using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ServiceManager : IServiceService
	{
		private readonly IServiceDal _serviceDal;

		public ServiceManager(IServiceDal serviceDal)
		{
			_serviceDal = serviceDal;
		}

		void IGenericService<Service>.Delete(Service t)
		{
			_serviceDal.Delete(t);
		}

		Service IGenericService<Service>.GetById(int id)
		{
			return _serviceDal.GetById(id);
		}

		List<Service> IGenericService<Service>.GetListAll()
		{
			return _serviceDal.GetListAll();
		}

		void IGenericService<Service>.Insert(Service t)
		{
			_serviceDal.Insert(t);
		}

		void IGenericService<Service>.Update(Service t)
		{
			_serviceDal.Update(t);
		}
	}
}
