using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{

    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> logger;

        public ValuesController(ILogger<ValuesController> logger) => this.logger = logger;

        [HttpGet("/status-failing")]
        public async Task<IActionResult> GetFailing()
        {
            this.logger.LogDebug("X-Correlation-ID: {0}", this.Request.Headers["X-Correlation-ID"]);
            this.logger.LogDebug("User-Agent: {0}", this.Request.Headers["User-Agent"]);
            await Task.Delay(1000);
            return new StatusCodeResult(500);
        }

        [HttpGet("/status-working")]
        public async Task<IActionResult> GetWorking()
        {
            this.logger.LogDebug("X-Correlation-ID: {0}", this.Request.Headers["X-Correlation-ID"]);
            this.logger.LogDebug("User-Agent: {0}", this.Request.Headers["User-Agent"]);
            await Task.Delay(1000);
            return Ok(new TakeoffStatus { Status = "Landed" });
        }
    }


    public class TakeoffStatus
    {
        public string Status { get; set; }
    }

    //[ApiController]
    //[Route("[controller]")]
    //public class WeatherForecastController : ControllerBase
    //{
    //    private static readonly string[] Summaries = new[]
    //    {
    //        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<WeatherForecastController> _logger;

    //    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        var rng = new Random();
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateTime.Now.AddDays(index),
    //            TemperatureC = rng.Next(-20, 55),
    //            Summary = Summaries[rng.Next(Summaries.Length)]
    //        })
    //        .ToArray();
    //    }
    //}
}
