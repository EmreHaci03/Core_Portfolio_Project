using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class Last5ProjectsViewComponent:ViewComponent
    {
        private readonly PortfolioManager portfolioManager;

        public Last5ProjectsViewComponent(PortfolioManager portfolioManager)
        {
            this.portfolioManager = portfolioManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList().TakeLast(5).ToList();
            return View("~/Views/Shared/Components/Dashboard/Last5Projects/Default.cshtml", values);
        }
    }
}
