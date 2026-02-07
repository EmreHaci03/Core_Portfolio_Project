using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class PortfolioViewComponentPartial:ViewComponent
    {
        private readonly PortfolioManager portfolioManager;

        public PortfolioViewComponentPartial(PortfolioManager portfolioManager)
        {
            this.portfolioManager = portfolioManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View(values);
        }
    }
}
