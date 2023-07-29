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
       

        [HttpGet("list")]
        public IActionResult GetAll() 
        {
            return Ok(Students);
        }

        [HttpGet("Detail/{id}")]
        public IActionResult GetById([Required] string id) 
        {
            var student = Students.FirstOrDefault(x => x.Id == Guid.Parse (id));
            if(student == null)
            {
                return NotFound("Không có dữ liệu");
            }
            return Ok(student);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] StudentDTO obj) 
        {
            try
            {
                var student = new Student()
                {
                    Id =Guid.NewGuid(),
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

        [HttpPut("update")]
        public IActionResult Update([FromBody]StudentDTO obj, string id)
        {
            try
            {
                
                var student = Students.FirstOrDefault(x => x.Id == Guid.Parse(id));
                if (student == null)
                {
                    return NotFound("Không có dữ liệu");
                }
                if(id != student.Id.ToString())
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
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string id)
        {
            try
            {
                 var student = Students.FirstOrDefault(x => x.Id .ToString() == id);
                if(student == null)
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
