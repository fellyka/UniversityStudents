using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace UniversityStudents.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        //private readonly ILogger<WeatherForecastController> _logger;
        private ILoggerManager _logger;

        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IEnumerable<string> GetLogging()
        {
            _logger.LogInfo("Here is INFO message from our values controller");
            _logger.LogDebug("Here is DEBUG message from our values controller");
            _logger.LogWarn("Here is WARN message from our values controller");
            _logger.LogError("Here is an ERROR message from our values controller");

            return new string[] { "Value1", "Value2" };
        }
    }
}