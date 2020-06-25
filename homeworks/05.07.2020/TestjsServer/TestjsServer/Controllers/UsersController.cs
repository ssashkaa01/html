using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestjsServer.Controllers
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Role { get; set; }
    }

    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class UsersController : ControllerBase
    {
        static List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Email = "slavic@gmail.com",
                    Image="https://tgram.ru/blog/wp-content/uploads/2017/06/admin_rights.gif",
                    Role="Admin"
                },
                new User
                {
                    Id = 2,
                    Email = "oksana@gmail.com",
                    Image="https://shkola.ukrfilm.tv/wp-content/uploads/2018/02/Oksana-1.jpg",
                    Role="GlobalAdmin"
                },
            };
        
        [HttpGet("search")]
        public IActionResult GetSearchUsers()
        {
            Thread.Sleep(2000);
            return Ok(users);
            //return BadRequest(new { error = "Труба" });
        }
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody]User user)
        {
            users.Add(user);
            //Thread.Sleep(2000);
            return Ok(user);
            //return BadRequest(new { error = "Труба" });
        }

    }
}
