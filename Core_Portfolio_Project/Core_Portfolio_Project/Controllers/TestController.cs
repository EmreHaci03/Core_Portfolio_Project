using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
