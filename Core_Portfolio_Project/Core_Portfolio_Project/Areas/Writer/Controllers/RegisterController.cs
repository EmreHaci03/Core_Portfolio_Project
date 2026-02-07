using Core_Portfolio_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Portfolio_Project.Areas.Writer.Controllers
{
    [AllowAnonymous]
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class RegisterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public RegisterController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var user = new WriterUser
            {
                Name = p.Name,
                Surname = p.Surname,
                Email = p.Mail,
                ImageUrl = p.ImageUrl,
                UserName = p.UserName
            };

            var result = await _userManager.CreateAsync(user, p.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(p);

        }
    }
}
