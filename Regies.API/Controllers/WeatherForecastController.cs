using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Regies.API.Controllers;


public class TemperaturesLimites
{
    public int min { get; set; }
    public int max { get; set; }
}


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
        return p_service.Get(-55, 50, 5);
    }

    [HttpGet]
    [Route("{take}/GetConstruct")]
    //https://localhost:7246/weatherforecast/31/GetConstruct?max=50
    public IActionResult Get([FromQuery] int max, [FromRoute] int take)
    {
        p_logger.LogInformation("Logged");
        var result = p_service.Get(-55, max, take);
        var argExc = new ArgumentException("Bad Arguments")
        {
            Source = "Vient d'ici"
        };
        argExc.Data.Add("result", result);

        return StatusCode(500, argExc);
    }

    [HttpGet("CurrentDay")]
    public WeatherForecast GetCurrentDay()
    {
        return p_service.Get(-55, 50, 5).First();
    }

    [HttpPost]
    public string Hello([FromBody] string name) => $"Hello {name}";


    // 1 Méthode Create
    // Qui renvoie un IActionResult
    // Depuis la Query, on récupère le nombre de résultats
    // Depuis le body, on va récupérer un objet Temps temperaturesLimites
    // qui contiendra les valeurs min et max à passer à la méthode Get

    // Si min > max OU si numberofResults < 0
    // => Renvoie une BadRequest

    //Sinon On renvoie Ok qui contient le résultat
    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromQuery] int resultsNumber, [FromBody] TemperaturesLimites temperaturesLimites)
    {
        int min = temperaturesLimites.min;
        int max = temperaturesLimites.max;
        if (min > max || resultsNumber <= 0)
        {
            p_logger.LogError("Invalid parameters");
            StringBuilder sb = new();
            sb.AppendLine( "Max : " + max.ToString() + ". Min : " + min.ToString() + ". Number of Results to be generated " + resultsNumber.ToString());
            if (min > max) sb.AppendLine("> max doit être plus grand que min.");
            if (resultsNumber <= 0) sb.AppendLine("> resultsNumber doit être 1 ou plus.");
            string message = sb.ToString();
            p_logger.LogError(message);
            return BadRequest("Invalid parameters\n"+message);
        }

        p_logger.LogInformation("Generating weather forecast");
        var result = p_service.Get(min, max, resultsNumber);
        return Ok(result);
    }
}
