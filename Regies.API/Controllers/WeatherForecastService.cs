namespace Regies.API.Controllers;


public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get(int min, int max, int Number);
}

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] s_Summaries = [
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    public IEnumerable<WeatherForecast> Get(int min, int max, int Number)
    {
        return Enumerable.Range(1, Number).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(min, max),
            Summary = s_Summaries[Random.Shared.Next(s_Summaries.Length)]
        })
        .ToArray();
    }
}
