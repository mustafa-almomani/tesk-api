using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.DTO;
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

        [HttpGet("product/GetProductById/{id}")]
        public IActionResult GetProductById(int id)
        {
            if (id <= 0)
            { return BadRequest(); }
            var products = _db.Products.Where(c => c.CategoryId == id);
            if (products == null)
            {
                return NotFound();

            }
            return Ok(products);
        }

        [HttpGet("product/GetProductByname/{name}")]
        public IActionResult GetProductByname(string name)
        {
            var products = _db.Products.Where(c => c.ProductName == name);
            if (products == null)
            {
                return NotFound();

            }
            return Ok(products);

        }

        [HttpDelete("product/delete{id}")]
        public IActionResult DeleteProductById(int id)
        {
            if (id <= 0)
            { return BadRequest(); }
            var product = _db.Products.FirstOrDefault(c => c.ProductId == id);
            if (product == null)
            {
                return NotFound();

            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return NoContent();
        }


        [HttpGet("getproductdecs")]
        public IActionResult getproductdecs()
        {
            var decs = _db.Products.OrderByDescending(c => c.Price).ToList();
            return Ok(decs);
        }

        [HttpPost]
        public IActionResult productDTO([FromForm] productrequestDTO product)
        {
            var product1 = new Product();
            product1.ProductName = product.ProductName;
            product1.Descr = product.Descr;
            product1.Price = product.Price;
            var uploadImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadImageFolder))
            {
                Directory.CreateDirectory(uploadImageFolder);
            }
            var imageFile = Path.Combine(uploadImageFolder, product.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                product.ProductImage.CopyToAsync(stream);
            }
            product1.ProductImage = product.ProductImage.FileName ?? product1.ProductImage;
            _db.Products.Add(product1);
            _db.SaveChanges();
            return Ok(product1);
        }


        [HttpPut("{id}")]
        public IActionResult productDTOput(int id, [FromForm] productrequestDTO obj)
        {
            var product = _db.Products.Find(id);
            product.ProductName = obj.ProductName ?? product.ProductName;
            product.Descr = obj.Descr ?? product.Descr;
            product.Price = obj.Price ?? product.Price;
      
            var uploadImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            if (!Directory.Exists(uploadImageFolder))
            {
                Directory.CreateDirectory(uploadImageFolder);
            }
            var imageFile = Path.Combine(uploadImageFolder, obj.ProductImage.FileName);
            using (var stream = new FileStream(imageFile, FileMode.Create))
            {
                obj.ProductImage.CopyToAsync(stream);
            }
            product.ProductImage = obj.ProductImage.FileName ?? product.ProductImage;
            _db.Update(product);
            _db.SaveChanges();
            return Ok();
        }

        [HttpGet("{num1}/{num2}")]
        public IActionResult number(int num1, int num2)
        {
            if (num1 == 30 || num2 == 30)
            {
                return Ok("true");
            }
            else if (num1 + num2 == 30)
            {
                return Ok("true");
            }
            else
            {
                return Ok("false");
            }

        }

        [HttpGet("{num1}")]
        public IActionResult number2(int num1)
        {
            if (num1 > 0 && num1 % 3 == 0 || num1 % 7 == 0)
            {
                return Ok("true");
            }
            else { return Ok("false");
            }

        }



        
    }
}
