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
    public class TestimonialManager:ITestimonialService
    {
        private readonly ITestimonialDal _ITestimonialDal;

        public TestimonialManager(ITestimonialDal ıTestimonialDal)
        {
            _ITestimonialDal = ıTestimonialDal;
        }

        public Testimonial GetByID(int id)
        {
            return _ITestimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetList()
        {
            return _ITestimonialDal.GetList();
        }

        public void Tadd(Testimonial t)
        {
            _ITestimonialDal.Insert(t);
        }

        public void TDelete(Testimonial t)
        {
            _ITestimonialDal.Delete(t);
        }

        public void TUpdate(Testimonial t)
        {
            _ITestimonialDal.Update(t);
        }

      
    }
}
