using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Core_Portfolio_Project.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        private readonly WriterMessageManager _writerMessageManager;
        private readonly Context _Context;

        public AdminMessageController(WriterMessageManager writerMessageManager,Context context)
        {
            _writerMessageManager = writerMessageManager;
            _Context= context;
        }

        public IActionResult ReceiverMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p);
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            string p;
            p = "admin@gmail.com";
            var values = _writerMessageManager.GetListSenderMessage(p);
            return View(values);
        }
        public IActionResult ReceiverDeleteMessage(int id)
        {
            var values = _writerMessageManager.GetByID(id);
            _writerMessageManager.TDelete(values);
            return RedirectToAction("ReceiverMessageList");
        }
        public IActionResult SenderDeleteMessage(int id)
        {
            var values = _writerMessageManager.GetByID(id);
            _writerMessageManager.TDelete(values);
            return RedirectToAction("SenderMessageList");
        }
        public IActionResult ReceiverMessageDetails(int id)
        {
            var values = _writerMessageManager.GetByID(id);
            return View(values);
        }
        public IActionResult SenderMessageDetails(int id)
        {
            var values = _writerMessageManager.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddMessage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMessage(WriterMessage writerMessage)
        {
            writerMessage.Sender = "admin@gmail.com";
            writerMessage.SenderName = "admin";
            writerMessage.Date =DateTime.Parse( DateTime.Now.ToShortDateString());
            var receiverusername = _Context.Users.Where(x => x.Email == writerMessage.Receiver).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            writerMessage.ReceiverName= receiverusername;
            _writerMessageManager.Tadd(writerMessage);
            return RedirectToAction("SenderMessageList");
        }
    }
}
