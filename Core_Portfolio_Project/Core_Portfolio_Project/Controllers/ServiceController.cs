using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly ServiceManager serviceManager;

        private readonly IValidator<Service> _validator;

        public ServiceController(ServiceManager serviceManager,IValidator<Service> validator)
        {
            this.serviceManager = serviceManager;
            _validator = validator;
        }

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.GetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]

        public IActionResult AddService(Service service)
        {
            serviceManager.Tadd(service);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult UpdateService(int id)
        {
            var values = serviceManager.GetByID(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdateService(Service service)
        {
            var result = _validator.Validate(service);

            if (result.IsValid)
            {
                serviceManager.TUpdate(service);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(service);
            }

        }
    }
}
