/// File: ArticlesController.cs
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1
using Microsoft.AspNetCore.Mvc;

//For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cpate6_WebAPI_Project1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        /// <summary>
        /// GET /api/v1/articles/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/<ArticlesController>
        [HttpGet]
        public ActionResult<string> Get(string key)
        {
            return Ok("Get Articles: " + key);
        } // end of GET /api/v1/articles/<key>
    }
}
