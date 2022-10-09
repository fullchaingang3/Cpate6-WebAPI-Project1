/// File:
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cpate6_WebAPI_Project1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// GET /api/v1/user/status/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/<UserController>
        [HttpGet("status/{key}")]
        public ActionResult<string> Get(string key)
        {
            return Ok("Get Status key: " + key);
        }

        //// GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// GET /api/v1/user/
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost("{user}")]
        public ActionResult<string> PostAsUser([FromBody]string user)
        {
            return Ok("Post as user: " + user);
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
