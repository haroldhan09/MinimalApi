using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using MinimalApi.Users.Api;
using MinimalApi.Users.Services;

namespace MinimalApi.Users;

public sealed class UsersModule(UsersApi api) : ICarterModule
{
    private const string BasePath = "/api/v1/users";
    
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup(BasePath)
            .WithTags("Users");

        group.MapGet("/details/{userId:int}", api.GetUserDetails)
            .WithName(nameof(api.GetUserDetails));
    }
    
    public static void Register(IServiceCollection services)
    {
        services.AddTransient<UsersApi>();
        services.AddTransient<IUserService, UserService>();
        
        Console.WriteLine("Users Module Registered");
    }
}