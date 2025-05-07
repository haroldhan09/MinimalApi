using MinimalApi.Users;
using MinimalApi.Weather;

namespace HarryApi;

public static class ServiceCollectionExtensions
{
    public static void AddModules(this IServiceCollection services)
    {
        services.AddWeatherModule();
        services.AddUserModule();
    }
}