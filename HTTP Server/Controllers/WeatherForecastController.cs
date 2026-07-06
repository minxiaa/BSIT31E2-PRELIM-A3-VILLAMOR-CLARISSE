using Microsoft.AspNetCore.Mvc;

namespace HTTP_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        //retrieves weather forecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20,55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
             .ToArray();
        }
        //creates weather forecast
        [HttpPost("(id)")]
        public IActionResult Post(int id)
        {
            return Ok();
        }
        //updates weather forecast
        [HttpPut("(id)")]
        public IActionResult Put(int id)
        {
            return Ok();
        }
        //deletes weather forecast
        [HttpDelete("(id)")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
