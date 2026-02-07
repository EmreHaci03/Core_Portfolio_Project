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
        private readonly IServiceDal _IServiceDal;

        public ServiceManager(IServiceDal ıServiceDal)
        {
            _IServiceDal = ıServiceDal;
        }

        public Service GetByID(int id)
        {
            return _IServiceDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _IServiceDal.GetList();
        }

        public void Tadd(Service t)
        {
            _IServiceDal.Insert(t);
        }

        public void TDelete(Service t)
        {
            _IServiceDal.Delete(t);
        }

        public void TUpdate(Service t)
        {
            _IServiceDal.Update(t);
        }

    }
}
