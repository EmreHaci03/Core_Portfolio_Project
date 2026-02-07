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
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly ISocialMediaDal _ISocialMediaDal;

        public SocialMediaManager(ISocialMediaDal ıSocialMediaDal)
        {
            _ISocialMediaDal = ıSocialMediaDal;
        }

        public SocialMedia GetByID(int id)
        {
            return _ISocialMediaDal.GetByID(id);   
        }

        public List<SocialMedia> TGetList()
        {
            return _ISocialMediaDal.GetList();
        }

        public void Tadd(SocialMedia t)
        {
            _ISocialMediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _ISocialMediaDal.Delete(t);
        }

        public void TUpdate(SocialMedia t)
        {
            _ISocialMediaDal.Update(t);
        }

      
    }
}
