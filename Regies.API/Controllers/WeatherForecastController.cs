using Microsoft.AspNetCore.Mvc;

namespace Regies.API.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> p_logger, IWeatherForecastService p_service)
 : ControllerBase
{
    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        p_logger.LogInformation("Logged");
        return p_service.Get();
    }
}
