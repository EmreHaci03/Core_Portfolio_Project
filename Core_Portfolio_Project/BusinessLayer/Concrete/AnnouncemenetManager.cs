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
    public class AnnouncemenetManager : IAnnouncementService
    {
        private readonly IAnnouncementDal announcementDal;

        public AnnouncemenetManager(IAnnouncementDal announcementDal)
        {
            this.announcementDal = announcementDal;
        }

        public Announcement GetByID(int id)
        {
            return announcementDal.GetByID(id);
        }

        public void Tadd(Announcement t)
        {
            announcementDal.Insert(t);
        }

        public void TDelete(Announcement t)
        {
            announcementDal.Delete(t);
        }

        public List<Announcement> TGetList()
        {
            return announcementDal.GetList();
        }

        public void TUpdate(Announcement t)
        {
            announcementDal.Update(t);
        }
    }
}
