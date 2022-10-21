using dlblair_webapi_first.Data.DataTransfer;
using edu.northeaststate.dlblair.cDatabaseConnectivity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

/// File: ArticlesController.cs
/// Name: Dave Blair
/// Class: CITC 1317
/// Semester: Fall 2022
/// Project: Article Jet
namespace dlblair_webapi_first.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        
        /// <summary>
        /// GET /api/v1/articles/<key>
        /// Returns all articles in the database
        /// </summary>
        /// <param name="articleID"></param>
        /// <returns>TBD</returns>
        [HttpGet("{key}")]
        public ActionResult<List<Article>> GetAllArticles(string key)
        {
            List<Article> articles = new List<Article>();
            DataLayer dl = new DataLayer();
            var results = dl.GetAUserByGUIDAsync(key);
            if (results.Result != null)
            {
                Task<List<Article>> appArticles = dl.GetAllArticlesAsync();
                articles = appArticles.Result;
                return Ok(articles);
            }
            else
            {               
                return BadRequest("The user key in not valid.");
            }
            
        }

        [HttpGet("Ratings/{key}")]
        public ActionResult<List<ArticleWithRatingDto>> GetAllArticlesWithRatings(string key)
        {
            List<ArticleWithRatingDto> articles = new List<ArticleWithRatingDto>();
            DataLayer dl = new DataLayer();
            var results = dl.GetAUserByGUIDAsync(key);
            if (results.Result != null)
            {
                Task<List<ArticleWithRatingDto>> appArticles = dl.GetAllArticlesWithAveRating();
                articles = appArticles.Result;
                return Ok(articles);
            }
            else
            {
                return BadRequest("The user key in not valid.");
            }

        }

    }
}
