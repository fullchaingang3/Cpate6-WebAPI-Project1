/// File:
/// Name: Christopher Pate
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Project 1
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cpate6_WebAPI_Project1.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        /// <summary>
        /// GET /api/v1/rating/<articleId>/<key>?type=avg
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET /api/v1/rating/<articleId>/<key>?type=avg
        [HttpGet("{articleID}/{key}")]
        public ActionResult<string> Get(int articleID, double rate)
        {
            return Ok("Get Rating Average for articleID: " + articleID + " is " + rate);
        }

        /// <summary>
        /// POST /api/v1/rating/<articleId>/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// POST /api/v1/rating/<articleId>/<key>
        [HttpPost("{articleID}/{key}")]
        public ActionResult<double> Post([FromForm] double value)
        {
            return Ok("Post this rating: " + value);
        }

        /// <summary>
        /// PATCH /api/v1/rating/<ratingId>/<key>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // PATCH /api/v1/rating/<ratingId>/<key>
        [HttpPatch("{ratingId}/{key}")]
        public ActionResult<double> Patch([FromForm] double value)
        {
            return Ok("Patch this rating: " + value);
        }

        /// <summary>
        /// DELETE /api/v1/rating/<ratingID>/<adminkey>
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE /api/v1/rating/<ratingID>/<adminkey>
        [HttpDelete("{ratingId}/{adminkey}")]
        public ActionResult<string> Delete(int rating)
        {
            return Ok("Deleted rating: " + rating);
        }
    }
}
