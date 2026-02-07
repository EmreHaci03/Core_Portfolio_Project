using BusinessLayer.Concrete;
using Core_Portfolio_Project.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SkillController : Controller
    {
        private readonly SkillManager skillManager;

        public SkillController(SkillManager skillManager)
        {
            this.skillManager = skillManager;
        }

        public IActionResult Index()
        {
            var values = skillManager.TGetList();
            
            return View(values);
        }

       
        [HttpGet]
        public IActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSkill(Skill skill)
        {
            skillManager.Tadd(skill);
            return RedirectToAction("Index");
        }


        public IActionResult DeleteSkill(int id)
        {
            var values = skillManager.GetByID(id);
            skillManager.TDelete(values);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var values = skillManager.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            skillManager.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
