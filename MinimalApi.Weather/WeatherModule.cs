using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Weather.Api;
using MinimalApi.Weather.Services;

namespace MinimalApi.Weather;

public sealed class WeatherModule(WeatherApi api) : ICarterModule
{
    private const string BasePath = "/api/v1/weather";
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags("Weather");
        
        group.MapGet("/forecast", api.GetWeatherForecast)
            .WithName(nameof(api.GetWeatherForecast));
        
        group.MapGet("/summary", api.GetSummary)
            .WithName(nameof(api.GetSummary));
    }
    
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<WeatherApi>();
        services.AddTransient<IWeatherService, WeatherService>();
        
        Console.WriteLine("Weather Module Registered");
    }
}