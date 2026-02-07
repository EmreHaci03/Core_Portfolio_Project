using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Portfolio_Project.ViewComponents.Dashboard
{
    public class TodoListViewComponent:ViewComponent 
    {
        private readonly TodoListManager todoListManager;

        public TodoListViewComponent(TodoListManager todoListManager)
        {
            this.todoListManager = todoListManager;
        }

        public IViewComponentResult Invoke()
        {
            var values = todoListManager.TGetList();
            return View("~/Views/Shared/Components/Dashboard/TodoList/Default.cshtml",values);
        }
    }
}
