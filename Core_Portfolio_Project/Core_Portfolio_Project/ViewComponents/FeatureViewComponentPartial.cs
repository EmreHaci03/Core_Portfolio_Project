using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class FeatureViewComponentPartial:ViewComponent
    {
        private readonly FeatureManager _FeatureManager;

        public FeatureViewComponentPartial(FeatureManager featureManager)
        {
            _FeatureManager = featureManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = _FeatureManager.TGetList();
            return View(values);
        }
    }
}
