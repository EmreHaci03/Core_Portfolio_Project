using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class AboutViewComponentPartial:ViewComponent
    {
        private readonly AboutManager aboutManager;

        public AboutViewComponentPartial(AboutManager aboutManager)
        {
            this.aboutManager = aboutManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = aboutManager.TGetList();
            return View(values);
        }
    }
}
