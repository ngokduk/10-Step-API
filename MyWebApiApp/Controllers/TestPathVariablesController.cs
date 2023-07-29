using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPathVariablesController : Controller
    {
        [HttpGet]
        [Route("test-path-variables/{id}/{name}")]
        public IActionResult Action(int id ,string name)
        {
           var res = new
            {
                id = id,
                name = name
            };
           return Ok(res);
        }
    }
}
