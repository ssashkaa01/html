using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestjsServer.Entities;

namespace TestjsServer.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("search")]
        public IActionResult GetSearchUsers()
        {
            var host = $"{this.Request.Scheme}://{this.Request.Host}";
            Thread.Sleep(2000);
            var list = _context.Users.Select(u=> new DbUser 
            {
                Id=u.Id,
                Role=u.Role,
                Image= host+"/images/"+u.Image,
                Email=u.Email
            }).ToList();
            return Ok(list);
            //return BadRequest(new { error = "Труба" });
        }
        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] DbUser user)
        {
            //user.Image = Path.GetFileName(user.Image);
            _context.Users.Add(user);
            _context.SaveChanges();
            var host = $"{this.Request.Scheme}://{this.Request.Host}";
            user.Image = host + "/images/" + user.Image;
            return Ok(user);
            //return BadRequest(new { error = "Труба" });
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", user.Image);
            if (System.IO.File.Exists(pathFile))
            {
                System.IO.File.Delete(pathFile);
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("edit/{id}")]
        public IActionResult EditUser(int id)
        {
            var host = $"{this.Request.Scheme}://{this.Request.Host}";
            var user = _context.Users.Select(u => new DbUser
            {
                Id = u.Id,
                Role = u.Role,
                Image = host + "/images/" + u.Image,
                Email = u.Email
            }).SingleOrDefault(u => u.Id == id);
            return Ok(user);
        }

        [HttpPost("edit")]
        public IActionResult UpdateUser([FromBody] DbUser user)
        {
            DbUser editedUser = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();

            if(editedUser == null)
            {
                return Ok("user not found");
            }

            editedUser.Role = user.Role;
            editedUser.Email = user.Email;
            _context.SaveChanges();

            return Ok(user);
        }

        [HttpPost("uploader")]
        public IActionResult UploadFile(IFormFile file)
        {
            string currentDir = Directory.GetCurrentDirectory(); //поточна папка де запустила сайт
            string exp = Path.GetExtension(file.FileName); //розширення файла
            string fileName = Guid.NewGuid().ToString() + exp; //нове імя файла
            string pathSave = Path.Combine(currentDir, "Upload", fileName);
            using (var stream = new FileStream(pathSave, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Ok(new { id = fileName });
        }

        [HttpPost("removefile")]
        public IActionResult RemoveFile(string name)
        {
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Upload", name);
            if (System.IO.File.Exists(pathFile))
            {
                System.IO.File.Delete(pathFile);
            }
            return Ok();
        }

    }
}
