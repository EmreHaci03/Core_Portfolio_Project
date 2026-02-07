using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Portfolio_Project.Areas.Writer.ViewComponents
{
    public class NavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public NavbarComponentPartial(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.p = values.ImageUrl;
            return View();
        }
    }
}
