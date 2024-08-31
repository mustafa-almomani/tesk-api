using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.DTO;
using task_2_api.Models;

namespace task_2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly MyDbContext _db;
        public CartItemController(MyDbContext db)
        {
            _db = db;
        }


        [HttpGet("getallitems/{userId}")]
        public IActionResult Getalldata(int userId)
        {
            var user = _db.Carts.FirstOrDefault(c => c.UserId == userId);

            var data = _db.CartItems.Where(x => x.CartId == user.CartId).Select(x => new cartItemResponseDTO
            {
                CartItemId = x.CartItemId,
                CartId = x.CartId,
                ProductId = x.ProductId,
                Quantity = x.Quantity,
                product = new productDTO
                {
                    ProductId = x.Product.ProductId,
                    ProductName = x.Product.ProductName,
                    Price = x.Product.Price,

                }


            });
            return Ok(data);
        }

        [HttpPost]
        public IActionResult addcart([FromBody] CartItemRequestDTO cart)
        {
            var data = new CartItem
            {
                CartId = cart.CartId,
                ProductId = cart.ProductId,
                Quantity = cart.Quantity,
            };
            _db.CartItems.Add(data);
            _db.SaveChanges();

            return Ok();
        }

        [HttpPut("cartitem/updateitem/{id}")]
        public IActionResult editproduct(int id,[FromBody] cartupdateDTO obj )
        {
            var cart = _db.CartItems.Find(id);
            cart.Quantity = obj.Quantity;
            _db.Update(cart);
            _db.SaveChanges();
            return Ok();
        }
        [HttpDelete("cartitem/deletitem/{id}")]
        public IActionResult deleteitem(int id)
        {
            var item = _db.CartItems.Find(id);
            _db.Remove(item);
            _db.SaveChanges();  
            return Ok();
        }


    }
}
