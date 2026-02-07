using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class FeatureStatisticsViewComponent:ViewComponent
    {
        private readonly Context _context;

        public FeatureStatisticsViewComponent(Context context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = _context.Skills.Count();
            ViewBag.v2 = _context.Messages.Where(x => x.Status == false).Count();
            ViewBag.v3 = _context.Messages.Where(x => x.Status == true).Count();
            ViewBag.v4 = _context.Experiences.Count();
            return View("~/Views/Shared/Components/Dashboard/FeatureStatistics/Default.cshtml");
        }
    }
}
