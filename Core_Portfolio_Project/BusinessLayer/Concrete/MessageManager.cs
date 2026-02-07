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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _IMessageDal;

        public MessageManager(IMessageDal ıMessageDal)
        {
            _IMessageDal = ıMessageDal;
        }

        public Message GetByID(int id)
        {
            return _IMessageDal.GetByID(id);
        }

        public List<Message> TGetList()
        {
            return _IMessageDal.GetList();
        }

        public void Tadd(Message t)
        {
             _IMessageDal.Insert(t);
        }

        public void TDelete(Message t)
        {
            _IMessageDal.Delete(t);
        }

        public void TUpdate(Message t)
        {
            _IMessageDal.Update(t);
        }   
    }
}
