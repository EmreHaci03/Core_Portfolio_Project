using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MessageController : Controller
    {
        private readonly MessageManager messageManager;

        public MessageController(MessageManager messageManager)
        {
            this.messageManager = messageManager;
        }

       

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            if (ModelState.IsValid)
            {
                message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                message.Status = true;
                messageManager.Tadd(message);
                return RedirectToAction("Index","Default");
            }
            return View();
        }
    }
}
