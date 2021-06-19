using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.v2
{
    [ApiVersion("2.0")]
    public class WeatherForecastController : BaseController<WeatherForecastController>
    {
        public WeatherForecastController(ILogger<WeatherForecastController> logger) : base(logger)
        {
        }

        [HttpGet("Get2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            var rng = new Random();
            return Enumerable.Range(1, 8).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
