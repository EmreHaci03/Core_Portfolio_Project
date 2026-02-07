using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class SkillViewComponentPartial:ViewComponent
    {
        private readonly SkillManager skillManager;

        public SkillViewComponentPartial(SkillManager skillManager)
        {
            this.skillManager = skillManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = skillManager.TGetList();
            return View(values);
        }
    }
}
