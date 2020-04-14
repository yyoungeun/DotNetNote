using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;


namespace DotNetNote.Controllers
{
    [Route("api/[controller]")]
    public class WebApiDemocontroller : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public JsonResult Get()
        {
            return Json(new { Name = "한글깨짐" });
        }

        // GET api/<controller>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        public JsonResult Post([FromBody]WebApiDemoClass name)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.Created;
                return Json(true);
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("실패");
        }
    }

    public class WebApiDemoClass
    {
        public int Id { get; set;}
        [Required]
        [StringLength(50, MinimumLength =3, ErrorMessage = "3자 이상")]

        public string Name { get; set; }
    }
}
