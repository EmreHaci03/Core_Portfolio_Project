using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class ExperienceViewComponentPartial:ViewComponent
    {
        private readonly ExperienceManager experienceManager;

        public ExperienceViewComponentPartial(ExperienceManager experiencemanager)
        {
            this.experienceManager = experiencemanager;
        }

        public IViewComponentResult Invoke()
        {
            var values = experienceManager.TGetList();
            return View(values);
        }
    }
}
