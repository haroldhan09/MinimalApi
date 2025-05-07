using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MinimalApi.Weather.Models;
using MinimalApi.Weather.Services;

namespace MinimalApi.Weather.Api;

public sealed class WeatherApi(IWeatherService weatherService)
    : CarterModule("/weather/v1")
{
    private readonly IWeatherService _weatherService = weatherService;
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/forecast", GetWeatherForecast).WithName("GetWeatherForecast");
        app.MapGet("/summary", GetSummary).WithName("GetSummary");
    }
    
    #region Actions
    
    /// <summary>
    /// [GET] /weather/v1/forecast
    /// </summary>
    /// <param name="httpContext"></param>
    private WeatherForecast[] GetWeatherForecast(HttpContext httpContext)
    {
        var forecast = _weatherService.GetWeatherForecast();
        
        // additional actions?
        
        return forecast;
    }
    
    /// <summary>
    /// [GET] /weather/v1/summary
    /// </summary>
    /// <param name="context"></param>
    private string GetSummary(HttpContext context)
    {
        return "test";
    }

    #endregion
}