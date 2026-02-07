using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    
    public class ProjectListViewComponent:ViewComponent
    {
        private readonly PortfolioManager portfolioManager;

        public ProjectListViewComponent(PortfolioManager portfolioManager)
        {
            this.portfolioManager = portfolioManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = portfolioManager.TGetList();
            return View("~/Views/Shared/Components/Dashboard/ProjectList/Default.cshtml",values);
        }
    }
}
