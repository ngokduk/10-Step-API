using Microsoft.AspNetCore.Mvc;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet("imageName")]
        public IActionResult GetImage(string imageName)
        {
            // Đường dẫn tới thư mục chứa file ảnh
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", imageName);

            // Kiểm tra xem file ảnh có tồn tại không
            if (System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            // Đọc nội dung file ảnh và trả về dưới dạng FileStreamResult
            var imageFileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            return new FileStreamResult(imageFileStream, "image/jpeg");
        }
    }
}
