using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        public static List<Hello> hellos = new List<Hello>();
        [HttpGet]
        public IActionResult Get() 
        {
            string Str = "Hello, world";
            return Ok(Str);
        }
        
    }
}
