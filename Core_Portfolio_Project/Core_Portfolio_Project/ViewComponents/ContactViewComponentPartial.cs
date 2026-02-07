using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents
{
    public class ContactViewComponentPartial:ViewComponent
    {
        private readonly ContactManager contactManager;

        public ContactViewComponentPartial(ContactManager contactManager)
        {
            this.contactManager = contactManager;
        }
     
        public IViewComponentResult Invoke()
        {
            var values = contactManager.TGetList();
            return View(values);
        }
    }
}
