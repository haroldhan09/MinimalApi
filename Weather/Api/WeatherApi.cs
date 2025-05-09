using Microsoft.AspNetCore.Http;
using MinimalApi.Weather.Services;

namespace MinimalApi.Weather.Api;

public sealed class WeatherApi(IWeatherService weatherService)
{
    /// <summary>
    /// [GET] /weather/v1/forecast
    /// </summary>
    /// <param name="httpContext"></param>
    public IResult GetWeatherForecast(HttpContext httpContext)
    {
        var forecast = weatherService.GetWeatherForecast();
        return TypedResults.Ok(forecast);
    }
    
    /// <summary>
    /// [GET] /weather/v1/summary
    /// </summary>
    /// <param name="context"></param>
    public IResult GetSummary(HttpContext context)
    {
        return TypedResults.Ok("some random summary");
    }
}