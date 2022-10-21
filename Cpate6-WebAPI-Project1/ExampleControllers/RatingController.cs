using dlblair_webapi_first.BusinessLayer;
using dlblair_webapi_first.Data.DataTransfer;
using edu.northeaststate.dlblair.cDatabaseConnectivity;
using Microsoft.AspNetCore.Mvc;

/// File: RatingController.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace dlblair_webapi_first.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {

        /// <summary>
        /// POST api/v1/Rating/articleID/12345
        /// Post a new Article Rating
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="key"></param>
        /// <param name="rating"></param>
        /// <returns>TBD</returns>
        [HttpPost]
        public ActionResult<string> Post([FromBody] Rating rating)
        {
            // is key valid
            DataLayer dl = new DataLayer();
            Task<User> user = dl.GetAUserByGUIDAsync(rating.UserID);

            if (user.Result != null && user.Result.IsActive == true)
            {
                // validate rating
                var result = BusLogLayer.ValidateRating(rating);
                if(result.ValidRating == true) 
                {
                    // post rating
                    var rateResult = dl.PostANewRatingAsync(rating);
                    if (rateResult.Result != 0)
                    {
                        return Ok(rating);
                    }
                    else
                    {
                        return BadRequest("Rating not posted in database.");
                    }
                }
                else
                {
                    return BadRequest(rating);
                }                
            }
            else
            {
                return BadRequest("User not valid.");
            }
            
        }

        /// <summary>
        /// PATCH api/v1/Rating/articleID/12345
        /// Update the rating for an article for a user
        /// </summary>
        /// <param name="ratingId"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns>TBD</returns>
        [HttpPatch("{ratingId}/{key}")]
        public ActionResult<string> Patch(int ratingId, string key, [FromBody] double value)
        {
            // is key valid

            // does rating key match user key

            // validate rating value

            // update a rating

            return Ok("Patch");
        }

        /// <summary>
        /// DELETE api/v1/Rating/articleID/12345
        /// Delete a rating if an admin
        /// </summary>
        /// <param name="ratingId"></param>
        /// <param name="key"></param>
        /// <returns>TBD</returns>
        [HttpDelete("{adminkey}")]
        public ActionResult<Rating> DeleteARating(string adminkey, [FromBody] RatingRto rating)
        {
            // is valid admin key
            // is key valid
            DataLayer dl = new DataLayer();
            Task<User> user = dl.GetAUserByGUIDAsync(adminkey);

            if (user.Result != null && user.Result.IsActive == true && user.Result.LevelID <= 2)
            {                

                Rating rating1 = new Rating();
                rating1.ArticleID = rating.ArticleID;
                rating1.UserID = rating.UserID;

                // delete rating from database
                var result = dl.DeleteARatingAsync(rating1);
                if(result.Result == 1)
                {
                    return Ok(rating);
                }
                else
                {
                    return BadRequest("Rating not deleted");
                }
                
            }
            else
            {
                return BadRequest("User is not valid");
            }
        }
    }
}
