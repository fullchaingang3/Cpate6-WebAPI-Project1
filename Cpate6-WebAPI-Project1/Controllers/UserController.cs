/// File: UserControllers.cs
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1
using Cpate6_WebAPI_Project1.DataTransfer;
using Cpate6_WebAPI_Project1.Models;
using dlblair_webapi_first.BusinessLayer;
using edu.northeaststate.cpate6.cDatabaseConnectivity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using UserDto = Cpate6_WebAPI_Project1.DataTransfer.UserDto;

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
        public ActionResult<string> PostAUser([FromBody] string value)
        {
            return Ok("Post s user: " + value);
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

        /// <summary>
        /// POST /api/v1/user/
        /// </summary>
        /// <param user="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] UserDto? user)
        {
            DataLayer dl = new DataLayer();
            var result = dl.PostANewUserAsync(User);

            if (user.Result != null)
            {
                if (BusLogLayer.ValidateUserDto(userDto).ValidUserDto)
                {
                    User user = new User();
                    user.Email = userDto.Email;
                    user.FirstName = userDto.FirstName;
                    user.LastName = userDto.LastName;

                    var results = dl.PostANewUserAsync(user);
                    if (results.Result > 0)
                    {
                        return Ok(userDto);
                    }
                    else
                    {     
                        return BadRequest("Not successful adding user to the database.");
                    }
                }
                else
                {
                    return BadRequest(userDto);
                }
            }
            else
            {
                return BadRequest("User key is not valid.");
            }
            return Ok("Return new key: " + userDto);
        } // end of POST /api/v1/user/
    }
}
