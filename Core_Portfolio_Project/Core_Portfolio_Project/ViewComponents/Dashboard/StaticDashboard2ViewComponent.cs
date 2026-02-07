using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class StaticDashboard2ViewComponent:ViewComponent
    {
        private readonly Context _context;

        public StaticDashboard2ViewComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Portfolios.Where(x=>x.Status==true).Count();
            ViewBag.v2 = _context.Messages.Count();
            ViewBag.v3 = _context.Services.Count();
            return View("~/Views/Shared/Components/Dashboard/StaticDashboard2/Default.cshtml");
        }
    }
}
