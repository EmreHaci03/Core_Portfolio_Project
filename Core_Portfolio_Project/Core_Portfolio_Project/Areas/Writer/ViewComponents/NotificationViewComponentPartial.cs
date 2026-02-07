using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio_Project.Areas.Writer.ViewComponents
{
    public class NotificationViewComponentPartial:ViewComponent
    {
        private readonly AnnouncemenetManager _announcemenetManager;

        public NotificationViewComponentPartial(AnnouncemenetManager announcemenetManager)
        {
            _announcemenetManager = announcemenetManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcemenetManager.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
