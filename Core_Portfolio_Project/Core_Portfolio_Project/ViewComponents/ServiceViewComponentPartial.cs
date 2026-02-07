using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace Core_Portfolio_Project.ViewComponents
{
    public class ServiceViewComponentPartial:ViewComponent
    {
        private readonly ServiceManager serviceManager;

        public ServiceViewComponentPartial(ServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
    }
}
