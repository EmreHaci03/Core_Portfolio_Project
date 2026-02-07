using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class SocialMediaViewComponentPartial:ViewComponent
    {
        private readonly SocialMediaManager _socialMediaManager;

        public SocialMediaViewComponentPartial(SocialMediaManager socialMediaManager)
        {
            _socialMediaManager = socialMediaManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaManager.TGetList();
            return View(values);
        }
    }
}
