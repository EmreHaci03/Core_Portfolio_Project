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
    public class WriterUserManager:IWriterUserService
    {
        private readonly IWriterUserDal writerUserDal;

        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            this.writerUserDal = writerUserDal;
        }

        public WriterUser GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Tadd(WriterUser t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(WriterUser t)
        {
            throw new NotImplementedException();
        }

        public List<WriterUser> TGetList()
        {
            return writerUserDal.GetList();
        }

        public void TUpdate(WriterUser t)
        {
            throw new NotImplementedException();
        }
    }
}
