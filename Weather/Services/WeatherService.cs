using MinimalApi.Weather.Models;

namespace MinimalApi.Weather.Services;

public sealed class WeatherService : IWeatherService
{
    // "database"
    private readonly string[] _summaries = 
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    
    public WeatherForecast[] GetWeatherForecast()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = _summaries[Random.Shared.Next(_summaries.Length)]
                })
            .ToArray();
        
        return forecast;
    }
}