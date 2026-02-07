using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class HeaderViewComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
