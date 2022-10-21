using dlblair_webapi_first.BusinessLayer;
using dlblair_webapi_first.Data.DataTransfer;
using edu.northeaststate.dlblair.cDatabaseConnectivity;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

/// File: ArticleController.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace dlblair_webapi_first.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        /// <summary>
        /// GET /api/v1/article/<articleId>/<key>
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns>TBD</returns>
        [HttpGet("{articleID}/{key}")]
        public ActionResult<Article> Get(int articleID, string key)
        {
            DataLayer dl = new DataLayer();
            var results = dl.GetAUserByGUIDAsync(key);
            if (results.Result != null)
            {
                var articleRresults = dl.GetArticlesByArticleIDAsync(articleID);
                if (articleRresults.Result != null)
                {
                    return Ok(articleRresults.Result);
                }
                else
                {
                    return BadRequest("No article by that ID in the database.");
                }
            }
            else
            {
                return BadRequest(key + " is not a valid user key.");
            }

        }

        [HttpGet("{articleID}/Ratings/{key}")]
        public ActionResult<Article> GetArticleWithRatings(int articleID, string key)
        {
            DataLayer dl = new DataLayer();
            var results = dl.GetAUserByGUIDAsync(key);
            if (results.Result != null)
            {
                var articleResults = dl.GetArticleWithRatingsByArticleIDAsync(articleID);
                if (articleResults.Result != null)
                {
                    return Ok(articleResults.Result);
                }
                else
                {
                    return BadRequest("No article by that ID in the database.");
                }
            }
            else
            {
                return BadRequest(key + " is not a valid user key.");
            }

        }

        // POST api/<ArticleController>
        /// <summary>
        /// /api/v1/article/<key>
        /// [FromBody new Article]
        /// </summary>
        /// <param name="value"></param>
        /// <returns>TBD</returns>
        [HttpPost("{key}")]
        public ActionResult<string> Post(string key, [FromBody] ArticleDto articleDto)
        {
            DataLayer dl = new DataLayer();
            var userResults = dl.GetAUserByGUIDAsync(key);

            if (userResults.Result != null)
            {
                if (BusLogLayer.ValidateArticleDto(articleDto).ValidArticleDto)
                {
                    Article article = new Article();
                    article.Title = articleDto.Title;
                    article.Summary = articleDto.Summary;
                    article.PostDate = articleDto.PostDate;
                    article.Link = articleDto.Link;
                    article.OwnerGuid = key;

                    var results = dl.PostANewArticleAsync(article);
                    if (results.Result > 0)
                    {
                        return Ok(articleDto);
                    }
                    else
                    {
                        return BadRequest("Not successful adding article to the database.");
                    }
                }
                else
                {
                    return BadRequest(articleDto);
                }
            }
            else
            {
                return BadRequest("User key is not valid.");
            }

        }

        /// <summary>
        /// /api/v1/article/<articleId>/<adminkey>
        /// An admin can delete an article by articleId
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="adminkey"></param>
        /// <returns>TBD</returns>
        [HttpDelete("{articleID}/{adminkey}")]
        public ActionResult<string> Delete(int articleID, string adminkey)
        {
            DataLayer dl = new DataLayer();
            var userResults = dl.GetAUserByGUIDAsync(adminkey);

            if (userResults.Result != null && userResults.Result.LevelID <= 2)
            {
                var results = dl.DeleteAnArticleAsync(articleID);
                if(results.Result != 0)
                {
                    return Ok("Successfully delete article ID: " + articleID);
                }
                else
                {
                    return BadRequest("Not successful deleting article ID: " + articleID);
                }
            }
            else
            {
                return BadRequest("User key not an admin.");
            }            
        }
    }
}
