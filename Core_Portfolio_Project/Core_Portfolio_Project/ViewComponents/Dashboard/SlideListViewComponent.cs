using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class SlideListViewComponent:ViewComponent
    {
        private readonly PortfolioManager portfolioManager;

        public SlideListViewComponent(PortfolioManager portfolioManager)
        {
            this.portfolioManager = portfolioManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View("~/Views/Shared/Components/Dashboard/SlideList/Default.cshtml", values);
        }
    }
}
