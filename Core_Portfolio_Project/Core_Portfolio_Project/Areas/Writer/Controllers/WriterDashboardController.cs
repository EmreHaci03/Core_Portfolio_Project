using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Portfolio_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class WriterDashboardController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly Context _context;

        public WriterDashboardController(UserManager<WriterUser> userManager , Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.v = values.Name+" " +values.Surname;

            //İstatistikler
            ViewBag.message =_context.WriterMessages.Where(x=>x.Receiver==values.Email).Count();
            ViewBag.MostMessagedReceiver = _context.WriterMessages.Where(x=>x.Sender==values.Email).GroupBy(x=>x.ReceiverName)
                .OrderByDescending(g=>g.Count()).Select(g => g.Key).FirstOrDefault(); 
            ViewBag.SenderMessageCount = _context.WriterMessages.Where(x=>x.Sender==values.Email).Count();
            ViewBag.LastSenderMessage = _context.WriterMessages .Where(x => x.Sender == values.Email)
                .OrderByDescending(x => x.Date).Select(x => x.ReceiverName).FirstOrDefault();

            return View();
        }
    }
}
