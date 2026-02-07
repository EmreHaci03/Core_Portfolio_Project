using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ExperienceAjaxController : Controller
    {
        private readonly ExperienceManager experienceManager;

        public ExperienceAjaxController(ExperienceManager experienceManager)
        {
            this.experienceManager = experienceManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListExperience()
        {
            var values = experienceManager.TGetList();
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            experienceManager.Tadd(p);
            return Json(p);
        }
        [HttpGet]
        public IActionResult GetExperienceById(int id)
        {
            var values = experienceManager.GetByID(id);
            return Json(values);
        }
        [HttpPost]
        public IActionResult DeleteExperience(int id)
        {
            var values = experienceManager.GetByID(id);
            experienceManager.TDelete(values);
            return Json(values);
        }

        //[HttpGet]
        //public IActionResult UpdateExperience(int id)
        //{
        //    var values = experienceManager.GetByID(id);
        //    return Json(values);
        //}

        //[HttpPost]
        //public IActionResult UpdateExperience(Experience p)
        //{
        //    experienceManager.TUpdate(p);
        //    return Json(p);
        //}
    }
}
