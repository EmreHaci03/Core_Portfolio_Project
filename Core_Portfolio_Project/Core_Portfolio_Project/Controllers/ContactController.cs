using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly MessageManager _messageManager;

        public ContactController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public IActionResult Index()
        {
            var values = _messageManager.TGetList();
            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _messageManager.GetByID(id);
            _messageManager.TDelete(values);
            return RedirectToAction("Index");
        }
        public IActionResult ContactDetails(int id)
        {
            var values = _messageManager.GetByID(id);
            return View(values);
        }
       

    }
}
