using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Users.Services;

namespace MinimalApi.Users;

public static class UserServiceCollection
{
    public static void AddUserModule(this IServiceCollection services)
    {
        services.AddTransient<IUserService, UserService>();
    }
}