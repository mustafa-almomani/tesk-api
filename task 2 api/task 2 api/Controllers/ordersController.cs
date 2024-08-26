using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.Models;

namespace task_2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {

        private readonly MyDbContext _db;

        public ordersController(MyDbContext db)
        {
            _db = db;
        }
        [HttpGet("order/getAllOrders")]
        public ActionResult getAllOrders()
        {
            var orders = _db.Users.ToList();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet("order/GetOrderById{id}")]
        public ActionResult GetOrderById(int id)
        {
            if (id == 0) { return BadRequest(); }
            var order = _db.Users.Find(id);
            if (order == null) { return NotFound(); }

            return Ok(order);
        }

        [HttpGet("order/GetOrderBydate {date}")]
        public ActionResult GetOrderBydate(string date)
        {
            if (date == null) { return BadRequest(); }
            var order = _db.Orders.FirstOrDefault(c => c.OrderDate == date);
            if (order == null) { return NotFound(); }
            return Ok(order);
        }


        [HttpGet("order/GetOrderByname {name}")]
        public ActionResult GetOrderByName(string name)
        {
            if (name == null) {
                return BadRequest(); 
            }
            var order = _db.Users.FirstOrDefault(c => c.Username == name);
            if (order == null) {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpDelete("order/delete{id}")]
        public ActionResult Delete(int id)
        {
            if(id == 0)
            { 
                return BadRequest(); 
            }
            var order = _db.Orders.FirstOrDefault(c=>c.OrderId==id);
            _db.Orders.Remove(order);
            _db.SaveChanges();
            return NoContent ();
        }

    }
}
