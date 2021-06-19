using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiVersioningDemo.Controllers.v1
{
    [ApiVersion("1.0")]
    public class WeatherForecastController : BaseController<WeatherForecast>
    {
        public WeatherForecastController(ILogger<WeatherForecast> logger) : base(logger)
        { }


        [Obsolete]
        [HttpGet("Get1")]
        public IEnumerable<WeatherForecast> Get1()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("Get3")]
        [MapToApiVersion("1.0")]
        [MapToApiVersion("2.0")]
        public IEnumerable<WeatherForecast> Get3()
        {
            var rng = new Random();
            return Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
