using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core_Portfolio_Project.Controllers
{
   [Authorize(Roles ="Admin")]
    public class ExperienceController : Controller
    {
        private readonly ExperienceManager experienceManager;

        private readonly IValidator<Experience> _validator;

        public ExperienceController(ExperienceManager experienceManager,IValidator<Experience> validator)
        {
            this.experienceManager = experienceManager;
            _validator = validator;
        }
       
        public IActionResult Index()
        {
            var values = experienceManager.TGetList();
            
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateExperience()
        {
            return View();
        }

        [HttpPost]

        public IActionResult CreateExperience(Experience experience)
        {
            experienceManager.Tadd(experience);
           return RedirectToAction("Index");
        }

        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.GetByID(id);
            experienceManager.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]

        public IActionResult UpdateExperience(int id)
        {
            var values = experienceManager.GetByID(id);
            return View(values);
        }

        [HttpPost]

        public IActionResult UpdateExperience(Experience experience)
        {
            experienceManager.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
