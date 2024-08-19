using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task1api.Models;

namespace task1api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly MyDbContext _db;

        public CategoriesController(MyDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public IActionResult getAllCategories()
        {
            var Categories = _db.Categories.ToList();
            return Ok(Categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryById(int id )
        {
            var Category = _db.Categories.Where(c=>c.CategoryId==id).FirstOrDefault();
            return Ok(Category);
        }
    }
}