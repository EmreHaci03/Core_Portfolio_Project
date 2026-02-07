using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core_Portfolio_Project.Controllers
{
    public class WriterUserController : Controller
    {
        private readonly WriterUserManager writerUserManager;

        public WriterUserController(WriterUserManager writerUserManager)
        {
            this.writerUserManager = writerUserManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListUser()
        {
            var values = JsonConvert.SerializeObject(writerUserManager.TGetList());
            return Json(values);
        }

        [HttpPost]
        public IActionResult AddUser(WriterUser p)
        {
            writerUserManager.Tadd(p);
            return Json(new
            {
                success = true,
                message = "Kullanıcı Eklendi",
                user = p
            });

        }
    }
}
