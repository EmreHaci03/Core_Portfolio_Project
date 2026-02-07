using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    public class ContactSidebarController : Controller
    {
        private readonly ContactManager _contactManager;

        public ContactSidebarController(ContactManager contactManager)
        {
            _contactManager = contactManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactManager.GetByID(1);
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactManager.TUpdate(contact);
            return RedirectToAction("Index","Default");
        }
    }
}
