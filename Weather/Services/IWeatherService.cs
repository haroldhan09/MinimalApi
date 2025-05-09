using MinimalApi.Weather.Models;

namespace MinimalApi.Weather.Services;

public interface IWeatherService
{
    WeatherForecast[] GetWeatherForecast();
}