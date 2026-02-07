using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    
    public class NavbarMessageViewComponent:ViewComponent
    {
        private readonly WriterMessageManager _writerMessageManager;

        public NavbarMessageViewComponent(WriterMessageManager writerMessageManager)
        {
            _writerMessageManager = writerMessageManager;
        }

        public IViewComponentResult Invoke()
        {
            string p = "admin@gmail.com";
            var values = _writerMessageManager.GetListReceiverMessage(p).OrderByDescending(x=>x.WriterMessageID).Take(3).ToList() ;
            return View("~/Views/Shared/Components/Dashboard/NavbarMessage/Default.cshtml",values);
        }
    }
}
