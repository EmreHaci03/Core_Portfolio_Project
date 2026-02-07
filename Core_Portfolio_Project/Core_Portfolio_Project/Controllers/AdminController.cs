using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    public class AdminController : Controller
    {
     
        public PartialViewResult NewSideBar()
        {
            return PartialView();
        }
     

    }
}
