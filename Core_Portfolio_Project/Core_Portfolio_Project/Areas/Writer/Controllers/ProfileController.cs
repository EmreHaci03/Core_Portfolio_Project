using Core_Portfolio_Project.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Core_Portfolio_Project.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();

            // UserEditViewModel kullanarak bütün valuesteki bütün bilgileri atmayarak daha güvenli hale getirdik.
            // Eğer values ile atsaydık Kullanıcı html kodlarında gizlenmiş bir şekilde bilgileri görecekti ve güvenlik açığı oluşacaktı.


            model.Name = values.Name;
            model.Surname = values.Surname;
            model.PictureUrl = values.ImageUrl;
            return View(model);
        }

        [HttpPost]

        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Picture != null)
            {
                //Projenin bulunduğu dizinin yolunu alır.
                var resource = Directory.GetCurrentDirectory();

                // Yüklenen dosyanın uzantısını alır (.jpg, .png gibi)
                var extension = Path.GetExtension(p.Picture.FileName);

                // Benzersiz bir dosya adı üretir (örnek: 8c9f-12aa-9a1b.jpg)
                var imagename = Guid.NewGuid() + extension;

                // Dosyanın kaydedileceği tam yolu oluşturur
                var saveLocation = Path.Combine(resource, "wwwroot/userimage/" + imagename);

                // Dosya için bir akış açılır.
                var stream = new FileStream(saveLocation,FileMode.Create);

                // Kullanıcının yüklediği fotoğrafı belirttiğimiz konuma kopyalar
                await p.Picture.CopyToAsync(stream);

                user.ImageUrl = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user,p.Password);
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Login");
            }
                return View();
        }
    }
}
