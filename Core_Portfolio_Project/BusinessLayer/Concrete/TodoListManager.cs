using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TodoListManager:ITodoListService
    {
        private readonly ITodoListDal todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            this.todoListDal = todoListDal;
        }

        public TodoList GetByID(int id)
        {
            return todoListDal.GetByID(id);
        }

        public void Tadd(TodoList t)
        {
            todoListDal.Insert(t);
        }

        public void TDelete(TodoList t)
        {
            todoListDal.Delete(t);
        }

        public List<TodoList> TGetList()
        {
            return todoListDal.GetList();
        }

     
        public void TUpdate(TodoList t)
        {
            todoListDal.Update(t);
        }
    }
}
