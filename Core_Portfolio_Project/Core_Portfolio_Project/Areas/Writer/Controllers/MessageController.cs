using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly WriterMessageManager _writerMessageManager;
        private readonly UserManager<WriterUser> _userManager;
        private readonly Context _context;

        public MessageController(WriterMessageManager writerMessageManager,UserManager<WriterUser> userManager,Context context)
        {
            _writerMessageManager = writerMessageManager;
            _userManager = userManager;
            _context = context;   
        }
        public async Task<IActionResult> ReceiverMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageManager.GetListReceiverMessage(p);
            return View(messageList);
        }

        public async Task<IActionResult> SenderMessage(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageManager.GetListSenderMessage(p);
            return View(messageList);
        }

        [HttpGet("{id}")]
        public IActionResult MessageDetails(int id)
        {
            var values=_writerMessageManager.GetByID(id);
            return View(values);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = values.Name + " " + values.Surname;
            p.Date = DateTime.Now;
            p.Sender = mail;
            p.SenderName = name;
            var userNameSurname = _context.Users.Where(x => x.Email == p.Receiver).Select(x =>x.Name+ " " + x.Surname).FirstOrDefault();
            p.ReceiverName = userNameSurname;
            _writerMessageManager.Tadd(p);
            return RedirectToAction("SenderMessage");
        }
    }
}
