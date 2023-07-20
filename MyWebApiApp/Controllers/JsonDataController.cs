using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApiApp.Models;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonDataController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> GetAll()
        {
            var Lists = new List<ListPerson>()
            {
                new ListPerson{id =1, name= "A",enable = true},
                new ListPerson{id =2, name= "B",enable = false},
            };
            var Infos = new Info { Id = 1, data = "message" };
            var JsonData = new
            {
                message = "Ok",
                Info = Infos,
                List = Lists
            };
            return Ok(JsonData);

        }
    }
}
