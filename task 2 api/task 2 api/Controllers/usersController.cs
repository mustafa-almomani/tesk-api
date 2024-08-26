using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_2_api.DTO;
using task_2_api.Models;

namespace task_2_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class usersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public usersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("users/getAllUsers")]
        public IActionResult getAllUsers()
        {
            var users = _db.Users.ToList();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("users/GetUserById{id}")]
        public IActionResult GetUserById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var user = _db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }


            return Ok(user);
        }
        [HttpGet]
        [Route("users/getAllUsersbyname{name}")]
        public IActionResult GetUserByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            var user = _db.Users.FirstOrDefault(c => c.Username == name);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpDelete]
        [Route("users/Delete{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id == 0) { return BadRequest(); }
            var user = _db.Users.FirstOrDefault(c => c.UserId == id);
            if (user == null) { return NotFound(); }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult adduser([FromForm] userRequestDTO obj)
        {
            var user = new User
            {
                Username = obj.Username,
                Password = obj.Password,
                Email = obj.Email,

            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok();
        }


        [HttpPut("{id}")]
        public IActionResult updateuser(int id ,[FromForm] userRequestDTO obj )
        {
            var user =_db.Users.Find(id);
            user.Username= obj.Username ?? user.Username;
            user.Password= obj.Password?? user.Password;
            user.Email= obj.Email ??user.Email;
            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok();
        }
    }
}
