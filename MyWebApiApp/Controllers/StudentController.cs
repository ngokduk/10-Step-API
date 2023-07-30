using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.DTO.Student;
using MyWebApiApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> Students = new List<Student>();

        /// <summary>
        /// Description : lấy toàn bộ dữ liệu
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public IActionResult GetAll()
        {
            return Ok(Students);
        }
        /// <summary>
        /// Description : phân trang 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("list-page")]
        public IActionResult Get(int pageNumber = 1, int pageSize = 3)
        {
            var totalStudents = Students.Count();
            var paginatedStudents = Students
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            var response = new
            {
                TotalItems = totalStudents,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Students = paginatedStudents
            };

            return Ok(response);
        }

        /// <summary>
        /// Description : phân trang có lọc theo tuổi
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="age"></param>
        /// <returns></returns>
        [HttpGet("list-page-by-age")]
        public IActionResult Get(int pageNumber = 1, int pageSize = 3, int? age = null)
        {
            if (age.HasValue)
            {
                  Students = Students.Where(s => s.Age == age).ToList();
            }

            var totalStudents = Students.Count();
            var paginatedStudents = Students
                                      .Skip((pageNumber - 1) * pageSize)
                                      .Take(pageSize)
                                      .ToList();

            var response = new
            {
                TotalItems = totalStudents,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Students = paginatedStudents
            };

            return Ok(response);
        }

        /// <summary>
        /// Description : lấy dữ liệu theo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Detail/{id}")]
        public IActionResult GetById([Required] string id)
        {
            var student = Students.FirstOrDefault(x => x.Id == Guid.Parse(id));
            if (student == null)
            {
                return NotFound("Không có dữ liệu");
            }
            return Ok(student);
        }
        /// <summary>
        /// Description : thêm dữ liệu
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost("add")]
        public IActionResult Add([FromBody] StudentDTO obj)
        {
            try
            {
                var student = new Student()
                {
                    Id = Guid.NewGuid(),
                    Name = obj.Name,
                    Age = obj.Age,
                    NameClass = obj.NameClass,
                    Description = obj.Description,
                    Active = true
                };
                Students.Add(student);
                return Ok(new
                {
                    Success = true,
                    Data = student
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Description : cập nhật dữ liệu theo id
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public IActionResult Update([FromBody] StudentDTO obj, string id)
        {
            try
            {

                var student = Students.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (student == null)
                {
                    return NotFound("Không có dữ liệu");
                }
                if (id != student.Id.ToString())
                {
                    return BadRequest();
                }
                student.Name = obj.Name;
                student.Age = obj.Age;
                student.NameClass = obj.NameClass;
                student.Description = obj.Description;
                student.Active = true;
                return Ok(new
                {
                    Success = true,
                    Data = student
                }
                );

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// descripton : xoá dữ liệu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                var student = Students.FirstOrDefault(x => x.Id.ToString() == id);
                if (student == null)
                {
                    return NotFound("không có dữ liệu.");
                }
                Students.Remove(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
