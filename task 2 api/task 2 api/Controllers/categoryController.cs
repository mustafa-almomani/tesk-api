using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.Models;

namespace task_2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class categoryController : ControllerBase
    {

        private readonly MyDbContext _db;

        public categoryController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult getAllCategories()
        {
            
            var Categories = _db.Categories.ToList();
            if (Categories == null)
            {
                return NotFound();
            }
            return Ok(Categories);
        }

        [HttpGet]
        [Route("Categories/ getCategoriesbyid/{id:min(3)}")]
        public IActionResult getCategory(int id) 
        {
            if (id <= 0)
            {
                return BadRequest(); 
            }
            var Categories = _db.Categories.Find(id);
            if (Categories == null)
            {
                return NotFound();
            }
            return Ok(Categories);
        }

        [HttpGet]
        [Route("Categories/CategoryByName{name}")]
        public IActionResult CategoryByNameCategoryByName(string name)
        {

            var Category = _db.Categories.FirstOrDefault(c=>c.CategoryName==name);
            if (Category == null) 
            {
                return NotFound();
            }
            return Ok(Category);
        }


        [HttpDelete]
        [Route("Categories/CategoryByid{id}")]
        public IActionResult DeleteCategory(int id) 
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var Category = _db.Categories.FirstOrDefault(c=>c.CategoryId==id);
            if (Category == null) 
            {
                return NotFound(); 
            }

            _db.Categories.Remove(Category);
            _db.SaveChanges();
            return NoContent();
        }






    }
}
