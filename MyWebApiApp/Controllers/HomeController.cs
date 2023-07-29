using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult SubmitForm([FromBody] UserDTO obj )
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(obj);

        }

    }
    public class UserDTO
    {
        [Required]
        [MaxLength(10,ErrorMessage = "Tên không được quá 10 kí tự")]
        public string Name { get; set; }
        [Required]
        [Range(18,60, ErrorMessage = "Tuổi phải lớn hơn 18 và nhỏ hơn 60 tuổi")]
        public int Age { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
