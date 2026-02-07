using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class MessageListViewComponent:ViewComponent
    {
        private readonly MessageManager _messageManager;

        public MessageListViewComponent(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _messageManager.TGetList();
            return View("~/Views/Shared/Components/Dashboard/MessageList/Default.cshtml", values);
        }
    }
}
