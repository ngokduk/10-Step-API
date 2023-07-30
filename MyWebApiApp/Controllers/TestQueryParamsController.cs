using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestQueryParamsController : ControllerBase
    {
        [HttpGet("test-query-params")]
        public IActionResult GetTestQueryParams([FromQuery] int id, [FromQuery] int abc, [FromQuery] int[] cb)
        {
            var data = new
            {
                Id = id,
                Abc = abc,
                Cb = cb
            };

            return Ok(data);
        }
    }
}
