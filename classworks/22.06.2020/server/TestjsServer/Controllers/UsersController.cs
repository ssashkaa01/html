using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestjsServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
    public class UsersController : ControllerBase
    {
        [HttpGet("search")]
        public IActionResult GetSearchUsers()
        {
            return Ok(new { id=1, name="Іван" });
            //return BadRequest(new { error = "Труба" });
        }

    }
}
