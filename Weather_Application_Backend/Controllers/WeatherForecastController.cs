using Microsoft.AspNetCore.Mvc;

namespace Weather_Application_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<int> _logger;

        public WeatherForecastController(ILogger<int> logger)
        {
            _logger = logger;
        }
         
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<int> Get()
        {
            return Enumerable.Range(1, 5).ToArray();
        }
    }
}
