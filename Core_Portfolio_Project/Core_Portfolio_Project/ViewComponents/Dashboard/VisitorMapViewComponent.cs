using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class VisitorMapViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Dashboard/VisitorMap/Default.cshtml");
        }
    }
}
