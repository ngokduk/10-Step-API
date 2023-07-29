using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestPathVariablesController : Controller
    {
        [HttpGet]
        [Route("test-path-variables/{id}/{action}")]
        public IActionResult TestPathVariables(int id, string action)
        {
            // Xử lý các path variable tại đây
            // Ví dụ: Trả về một object JSON chứa các giá trị path variable
            var result = new
            {
                Id = id,
                Action = action
            };

            // Trả về JSON data
            return Ok(result);
        }
    }
}
