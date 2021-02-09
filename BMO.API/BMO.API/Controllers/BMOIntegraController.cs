using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using BMO.Business;
using System.Threading.Tasks;

namespace BMO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BMOIntegraController : ControllerBase
    {
        private readonly BMOIntegraBusiness _business;

        public BMOIntegraController(BMOIntegraBusiness business)
        {
            _business = business;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<BMOIntegraController> _logger;

        public BMOIntegraController(ILogger<BMOIntegraController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
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
    }
}
