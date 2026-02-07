using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    
    public class AdminNotificationsViewComponent:ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            return View("~/Views/Shared/Components/Dashboard/AdminNotifications/Default.cshtml");
        }
    }
}
