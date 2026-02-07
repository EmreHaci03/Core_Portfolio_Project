using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_Portfolio_Project.ViewComponents
{
    public class SendMessageViewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        } 
    }
}
