using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.Models;

namespace task_2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class productController : ControllerBase
    {
        private readonly MyDbContext _db;

        public productController(MyDbContext db)
        { 
            _db = db;
        }

        [HttpGet("product/getAllProducts")]
        public IActionResult getAllProducts() 
        {
            var product = _db.Products.ToList();
            if (product == null)
            {
                return NotFound();

            }
            return Ok(product);
        }

        [HttpGet("product/GetProductById/{id:max(3)}")]
        public IActionResult GetProductById(int id)
        {
            if (id <= 0)
            { return BadRequest(); }
            var products = _db.Products.Where(c => c.ProductId == id );
            if (products == null)
            {
                return NotFound();

            }
            return Ok(products);
        }

        [HttpGet("product/GetProductByname/{name}")]
        public IActionResult GetProductByname(string name)
        {
            var products = _db.Products.Where(c =>c.ProductName == name);
            if (products == null)
            {
                return NotFound();

            }
            return Ok(products);

        }

        [HttpDelete("product/delete{id}")]
        public IActionResult DeleteProductById(int id  )
        {
            if(id <=0)
            { return BadRequest(); }
            var product = _db.Products.FirstOrDefault(c=>c.ProductId == id);
            if (product == null)
            {
                return NotFound();
            
            }
           
                _db.Products.Remove(product);
                _db.SaveChanges();
            
            return NoContent();
        }










    }
}
