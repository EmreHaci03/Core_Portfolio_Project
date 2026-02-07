using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly FeatureManager featureManager;

        private readonly IValidator<Feature> _validator;

        public FeatureController(FeatureManager featureManager, IValidator<Feature> validator)
        {
            this.featureManager = featureManager;
            _validator = validator;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkanlar";
            ViewBag.v2 = "Öne Çıkan Sayfası";
            var values = featureManager.GetByID(1);
            return View(values);
        }

        [HttpPost]

        public IActionResult EditFeature(Feature feature)
        {
            var result = _validator.Validate(feature);

            if (result.IsValid)
            {
                featureManager.TUpdate(feature);
                return RedirectToAction("Index", "Default");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return View(feature);
        }
    }
}
