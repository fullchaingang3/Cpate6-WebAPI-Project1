/// File: UserControllers.cs
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1
using Cpate6_WebAPI_Project1.Models;
using dlblair_webapi_first.BusinessLayer;
using edu.northeaststate.cpate6.cDatabaseConnectivity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
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
            DataLayer dl = new DataLayer();
            var results = dl.GetAUserByGUIDAsync(key);
            if (results.Result != null)
            {
                return Ok(results.Result);
            }
            else
            {
                return BadRequest(key + " is not a valid user key.");
            }
        } // end of GET /api/v1/user/status/<key>

        /// <summary>
        /// POST /api/v1/user/<adminkey>
        /// </summary>
        /// <param user="user"></param>
        /// <returns></returns>
        //// POST /api/v1/user/<adminkey>
        [HttpPost("{adminkey}")]
        public ActionResult<string> PostAsAdmin(string adminkey, [FromBody] UserDto userdto)
        {
            DataLayer dl = new DataLayer();
            Task<User> user = dl.GetAUserByGUIDAsync(adminkey);

            if (user.Result != null && user.Result.IsActive == true && user.Result.LevelID <= 2)
            {
                var validUserDto = BusLogLayer.ValidateUserDto(userdto);
                if (BusLogLayer.ValidateUserDto(userdto).ValidUserDto)
                {
                    User user1 = new User();
                    user1.Email = userdto.Email;
                    user1.FirstName = userdto.FirstName;
                    user1.LastName = userdto.LastName;

                    var results = dl.PostANewUserAsync(user1);
                    if (validUserDto.ValidUserDto)
                    {
                        var email = validUserDto.Email;
                        var firstName = validUserDto.FirstName;
                        var lastName = validUserDto.LastName;

                        // create hashes

                        SHA256 sha256Hash = SHA256.Create();
                        var hashPass = BusLogLayer.GetHash(sha256Hash, userdto.Password);
                        var guid = Guid.NewGuid().ToString();

                        // create new User Model to submit to database
                        User user2 = new User();
                        user2.UserGUID = guid;
                        user2.Email = email;
                        user2.Password = hashPass;
                        user2.FirstName = firstName;
                        user2.LastName = lastName;
                        user2.IsActive = false;
                        user2.LevelID = 4;

                        // add to database
                        DataLayer dl2 = new DataLayer();
                        var results1 = dl.PostANewUserAsync(user2);

                        // return User object showing fields successful
                        validUserDto.Password = "NA";

                        if (results.Result == 0)
                        {
                            validUserDto.ValidUserDto = false;
                            return BadRequest(validUserDto);
                        }
                        else
                        {
                            validUserDto.ValidUserDto = true;
                            return Ok("Please save your new key: " + guid);
                        }
                    }
                    else
                    {
                        // failed validation
                        return BadRequest(validUserDto);
                    }

                }
                else
                {
                    // failed validation
                    return BadRequest(validUserDto);
                }
            }
            else
            {
                // failed validation
                return BadRequest("User was not added");
            }
        } // end of POST /api/v1/user/<adminkey>

        /// <summary>
        /// POST /api/v1/user/
        /// </summary>
        /// <param user="user"></param>
        /// <returns></returns>
        // POST api/<UserController>
        [HttpPost]
        public ActionResult<UserDto> PostAsUser([FromBody] UserDto userDto)
        {
            // check all data received in the UserDto object
            var validUserDto = BusLogLayer.ValidateUserDto(userDto);

            if (validUserDto.ValidUserDto)
            {
                var email = userDto.Email;
                var firstName = userDto.FirstName;
                var lastName = userDto.LastName;

                // create hashes

                SHA256 sha256Hash = SHA256.Create();
                var hashPass = BusLogLayer.GetHash(sha256Hash, userDto.Password);
                var guid = Guid.NewGuid().ToString();

                // create new User Model to submit to database
                User user = new User();
                user.UserGUID = guid;
                user.Email = email;
                user.Password = hashPass;
                user.FirstName = firstName;
                user.LastName = lastName;
                user.IsActive = false;
                user.LevelID = 4;

                // add to database
                DataLayer dl = new DataLayer();
                var results = dl.PostANewUserAsync(user);

                // return User object showing fields successful
                validUserDto.Password = "NA";

                if (results.Result == 0)
                {
                    validUserDto.ValidUserDto = false;
                    return BadRequest(validUserDto);
                }
                else
                {
                    validUserDto.ValidUserDto = true;
                    return Ok("Please save your new key: " + guid);
                }

            }
            else
            {
                // failed validation
                return BadRequest(validUserDto);
            }

        } // end PostAsUser

        /// <summary>
        /// PATCH /api/v1/user/<adminkey>?active=<bool>
        /// </summary>
        /// <param name="id"></param>
        // PATCH api/<UserController>/5
        [HttpPatch("{adminkey}")]
        public ActionResult<string> Patch(string adminkey, [FromQuery] bool status, UserDto userDto)
        {
            DataLayer dl = new DataLayer();
            Task<User> user = dl.GetAUserByGUIDAsync(adminkey);

            if (user.Result != null && user.Result.IsActive == true && user.Result.LevelID <= 2)
            {
                User user1 = new User();
                //user1.UserGUID = userDto.GUID;
                user1.Email = userDto.Email;
                user1.Password = userDto.Password;

                var result = BusLogLayer.ValidateUserDto(userDto);
                if (result.ValidUserDto == true)
                {
                    var userResult = dl.PutAUsersStateAsync(adminkey, status);
                    if (userResult.Result == 1)
                    {
                        return Ok(userDto);
                    }
                    else
                    {
                        return BadRequest("User not patched");
                    }
                }
                else
                {
                    return BadRequest("User not patched");
                }
            }
            else
            {
                return Ok("Patch was successful.");
            }
        } // end of POST /api/v1/user/<adminkey>

/// <summary>
/// Delete /api/v1/user/<adminkey>/<userkey>
/// </summary>
/// <param name="id"></param>
// DELETE api/<UserController>/5
[HttpDelete("{userkey}/{adminkey}")]
        public ActionResult<UserDto> Delete(string adminkey, string userkey, UserDto userDto)
        {
            DataLayer dl = new DataLayer();
            Task<User> User = dl.GetAUserByGUIDAsync(adminkey);

            if (User.Result != null && User.Result.IsActive == true && User.Result.LevelID <= 2)
            {
                User user1 = new User();
                user1.Email = userDto.Email;
                user1.FirstName = userDto.FirstName;
                user1.LastName = userDto.LastName;

                return BadRequest("User was not deleted.");
            }
            else
            {
                return Ok("Deleted user: " + userkey);
            }
        } // end of Delete /api/v1/user/<userkey>/<adminkey>
    }
}

