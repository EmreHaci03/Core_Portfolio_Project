using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Authorize]
    public class DefaultController : Controller
    {
        private readonly AnnouncemenetManager announcemenetManager;

        public DefaultController(AnnouncemenetManager announcemenetManager)
        {
            this.announcemenetManager = announcemenetManager;
        }

        public IActionResult Index()
        {
            var values = announcemenetManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AnnouncemenetDetails(int id)
        {
            var values = announcemenetManager.GetByID(id);
            return View(values);
        }
    }
}
