using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Weather.Services;

namespace MinimalApi.Weather;

public static class WeatherServiceCollection
{
    public static void AddWeatherModule(this IServiceCollection services)
    {
        services.AddTransient<IWeatherService, WeatherService>();
    }
}