using dlblair_webapi_first.Data.DataTransfer;
using edu.northeaststate.dlblair.cDatabaseConnectivity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

/// File: RatingsController.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace dlblair_webapi_first.Controllers
{
    
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        
        /// <summary>
        /// GET: api/v1/Rating/<articleID>/<key>
        /// Get an Article by article id and user key
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="key"></param>
        /// <returns>TBD</returns>
        [HttpGet("{articleID}/{key}")]
        public ActionResult<string> Get(int articleID, string key)
        {
            DataLayer dl = new DataLayer();
            Task<List<RatingsByArticleIdDto>>? articleRatings = null;
            Task<User> userTask = dl.GetAUserByGUIDAsync(key);
            if (userTask.Result != null && userTask.Result.IsActive == true)
            {
                articleRatings = dl.GetAllRatingsByArticleIDAsync(articleID);
                return Ok(articleRatings.Result);
            }
            else
            {
                return BadRequest("User key is not valid.");
            }                        
        }
    }
}
