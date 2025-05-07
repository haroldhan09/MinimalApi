using MinimalApi.Users;
using MinimalApi.Weather;

namespace MinimalApi;

public static class ServiceCollectionExtensions
{
    public static void AddModules(this IServiceCollection services)
    {
        services.AddWeatherModule();
        services.AddUserModule();
    }
}