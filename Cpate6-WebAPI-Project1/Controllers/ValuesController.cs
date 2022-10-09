//using Microsoft.AspNetCore.Mvc;

//// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace Cpate6_WebAPI_Project1.Controllers
//{
//    [Route("api/v1/[controller]")]
//    [ApiController]
//    public class ValuesController : ControllerBase
//    {
//        // GET: api/<ValuesController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        //// GET api/<ValuesController>/5
//        //[HttpGet("{id}")]
//        //public string Get(int id)
//        //{
//        //    return "value";
//        //}

//        // GET api/<ValuesController>/
//        [HttpGet("{id}")]
//        public string Get(int id, [FromQuery] string key, string key2)
//        {
//            return "GET: "+ id + " " + key + " " + key2;
//        }

//        // POST api/<ValuesController>
//        [HttpPost]
//        public ActionResult<string> Post([FromBody] string value)
//        {
//            return Ok("In Post: " + value);
//        }

//        // PUT api/<ValuesController>/5
//        [HttpPut("{id}")]
//        public ActionResult<string> Put(int id, [FromBody] string value)
//        {
//            return Ok("In Put: " + id + " " + value);
//        }

//        // DELETE api/<ValuesController>/5
//        [HttpDelete("{id}")]
//        public ActionResult<string> Delete(int id)
//        {
//            return Ok("In Delete");
//        }
//    }
//}
