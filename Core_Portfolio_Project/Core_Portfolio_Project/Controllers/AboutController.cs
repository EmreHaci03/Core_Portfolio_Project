using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly AboutManager aboutManager;

        private readonly IValidator<About> _validator;

        public AboutController(AboutManager aboutManager, IValidator<About> validator)
        {
            this.aboutManager = aboutManager;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var values = aboutManager.GetByID(1);
            return View(values);
        }

        [HttpPost]

        public IActionResult Index(About about)
        {
            var result = _validator.Validate(about);

            if (result.IsValid)
            {
                aboutManager.TUpdate(about);
                return RedirectToAction("Index", "Default");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(about);
        }
    }
}
