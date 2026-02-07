using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class TestimonialViewComponentPartial:ViewComponent
    {
        private readonly TestimonialManager testimonialManager;

        public TestimonialViewComponentPartial(TestimonialManager testimonialManager)
        {
            this.testimonialManager = testimonialManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
    }
}
