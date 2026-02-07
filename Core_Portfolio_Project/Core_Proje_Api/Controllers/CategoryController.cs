using Core_Proje_Api.DAL.Context;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context context;

        public CategoryController(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult CategoryList()
        {
            return Ok(context.Categories.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult CategoryListByID(int id)
        {
            var value = context.Categories.Find(id);

            if (value == null)
            {
                return NotFound();
            }
            else
                return Ok(value);
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            context.Add(p);
            context.SaveChanges();
            return Created("",p);
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value=context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
             context.Remove(value);
             context.SaveChanges();
             return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            var value = context.Find<Category>(category.CategoryID);

            if(value == null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName=category.CategoryName;
                context.Update(value);
                context.SaveChanges();
                return NoContent();
            }

        }

        

        
    }
}
