using Microsoft.AspNetCore.Mvc;

namespace Cpate6_WebAPI_Project1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet("{id}/{key}")]
        public ActionResult<string> Get(string id, string key)
        {
            if (key != "12345")
                return BadRequest("Bad API key");
            else
                return Ok("Good API key");
        }
    }
}