using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly TestimonialManager testimonialManager;

        public TestimonialController(TestimonialManager testimonialManager)
        {
            this.testimonialManager = testimonialManager;
        }

        public IActionResult Index()
        {
            var values = testimonialManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            return View(); 
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial p)
        {
            testimonialManager.Tadd(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values =testimonialManager.GetByID(id);
            testimonialManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult TestimonialDetails(int id)
        {
            var values = testimonialManager.GetByID(id);
            return View(values);
        }
    }
}
