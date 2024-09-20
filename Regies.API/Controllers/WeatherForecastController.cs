using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Regies.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> p_logger, IWeatherForecastService p_service)
 : ControllerBase
{
    [HttpGet]
    [Route("ExampleGet")]
    public IEnumerable<WeatherForecast> Get()
    {
        p_logger.LogInformation("Logged");
        return p_service.Get(50, 5);
    }

    [HttpGet]
    [Route("{take}/GetConstruct")]
    //https://localhost:7246/weatherforecast/31/GetConstruct?max=50
    public IActionResult Get([FromQuery]int max, [FromRoute] int take)
    {
        p_logger.LogInformation("Logged");
        var result = p_service.Get(max, take);
        var argExc = new ArgumentException("Bad Arguments");
        argExc.Source = "Vient d'ici";
        

        return StatusCode(500, argExc);
        return StatusCode(400,result);
        
    }

    [HttpGet("CurrentDay")]
    public WeatherForecast GetCurrentDay()
    {
        return p_service.Get(50, 5).First();
    }

    [HttpPost]
    public string Hello([FromBody] string name) => $"Hello {name}";
}
