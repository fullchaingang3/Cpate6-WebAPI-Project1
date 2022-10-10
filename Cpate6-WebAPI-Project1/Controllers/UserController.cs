/// File: UserControllers.cs
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
        } // end of GET /api/v1/user/status/<key>

        /// <summary>
        /// POST /api/v1/user/<adminkey>
        /// </summary>
        /// <param user="user"></param>
        /// <returns></returns>
        //// POST /api/v1/user/<adminkey>
        [HttpPost("{adminkey}")]
        public ActionResult<string> Post([FromBody] string key)
        {
            return Ok("Post adminkey: " + key);
        } // end of POST /api/v1/user/<adminkey>

        /// <summary>
        /// POST /api/v1/user/
        /// </summary>
        /// <param user="user"></param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost]
        public ActionResult<string> PostAsUser([FromBody] string value)
        {
            return Ok("Post as user: " + value);
        } // end of POST /api/v1/user/

        /// <summary>
        /// PATCH /api/v1/user/<adminkey>?active=<bool>
        /// </summary>
        /// <param name="id"></param>
        // PATCH api/<UserController>/5
        [HttpPatch("{adminkey}")]
        public ActionResult<string> Patch(string adminkey, [FromQuery] string status)
        {
            return Ok("Patch: user active: " + status);
        } // end of PATCH /api/v1/user/<adminkey>?active=<bool>

        /// <summary>
        /// Delete /api/v1/user/<userkey>/<adminkey>
        /// </summary>
        /// <param name="id"></param>
        // DELETE api/<UserController>/5
        [HttpDelete("{userkey}/{adminkey}")]
        public ActionResult<string> Delete(string userkey)
        {
            return Ok("Deleted user: " + userkey);
        } // end of Delete /api/v1/user/<userkey>/<adminkey>
    }
}
