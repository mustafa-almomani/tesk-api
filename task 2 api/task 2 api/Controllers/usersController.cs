using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult updateuser(int id, [FromForm] userRequestDTO obj)
        {
            var user = _db.Users.Find(id);
            user.Username = obj.Username ?? user.Username;
            user.Password = obj.Password ?? user.Password;
            user.Email = obj.Email ?? user.Email;
            _db.Users.Update(user);
            _db.SaveChanges();
            return Ok();
        }


        //[HttpPost("regester")]
        //public IActionResult addUSer([FromForm] UserDTONew userDTO)
        //{
        //    byte[] hash;
        //    byte[] salt;

        //    passwordHasherMethod.createPasswordHash(userDTO.Password,out hash,out salt);

        //    var user = new User
        //    {
        //        Username = userDTO.Username,
        //        Password = userDTO.Password,
        //        PasswordHash = hash ,
        //        PasswordSalt = salt,
        //        Email = userDTO.Email

        //    };
        //    _db.Users.Add(user);
        //    _db.SaveChanges();
        //    return Ok(user);
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult<string>> Login(UserDTONew model)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        //    if (user == null || !passwordHasherMethod.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return Unauthorized("Invalid username or password.");//401
        //    }
        //    // Generate a token or return a success response
        //    return Ok("User logged in successfully");
        //}


        [HttpPost("login")]
      public  IActionResult login(UserDTO userDTO)
        {
            var user = _db.Users.FirstOrDefault(x=> x.Email== userDTO.Email);
            if(user==null ||!passwordHasherMethod.VerifyPasswordHash(userDTO.Password,user.PasswordHash,user.PasswordSalt))
            {
                return Unauthorized("Invalid username or password.");
            }

            return Ok("User logged in successfully");
        }

        [HttpPost("register")]
        public IActionResult register([FromForm] UserDTO userDTO)
        {
            byte[] hash;
            byte[] salt;
              passwordHasherMethod.createPasswordHash(userDTO.Password,out hash,out salt);


            var user = new User
            {
                Username = userDTO.Username,
                Email = userDTO.Email,
                Password = userDTO.Password,
                PasswordHash = hash,
                PasswordSalt = salt
            };
            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }
    }
}
