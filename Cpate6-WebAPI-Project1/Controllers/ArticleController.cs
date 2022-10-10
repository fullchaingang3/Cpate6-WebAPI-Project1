/// File: ArticlesController.cs
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
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// GET /api/v1/article/<articleId>/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET /api/v1/article/<articleId>/<key>
        [HttpGet("{articleID}/{key}")]
        public ActionResult<string> Get(int articleID, string key)
        {
            return Ok("Get Article: " + articleID + " " + key);
        } // end of GET /api/v1/article/<articleId>/<key>

        /// <summary>
        /// POST /api/v1/article/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // POST api/<ArticleController>
        [HttpPost("{key}")]
        public ActionResult<string> Post([FromBody] string article)
        {
            return Ok("Post Article: " + article);
        } // end of POST /api/v1/article/<key>

        /// <summary>
        /// DELETE /api/v1/article/<articleId>/<adminkey>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE /api/v1/article/<articleId>/<adminkey>
        [HttpDelete("{articleId}/{adminkey}")]
        public ActionResult<string> Delete(int articleID)
        {
            return Ok("Deleted article: " + articleID);
        }
    }
}
