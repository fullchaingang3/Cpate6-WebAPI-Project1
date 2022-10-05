using Microsoft.AspNetCore.Mvc;

namespace Cpate6_WebAPI_Project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Hello API World";
        }
    }
}