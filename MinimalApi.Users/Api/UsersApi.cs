using Carter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MinimalApi.Users.Models;
using MinimalApi.Users.Services;

namespace MinimalApi.Users.Api;

public sealed class UsersApi(IUserService userService)
    : CarterModule("/users/v1")
{
    private readonly IUserService _userService = userService;
    
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/details/{userId:int}", GetUserDetails).WithName("GetUserDetails");
    }

    #region Actions
    
    /// <summary>
    /// [GET] /users/v1/details/{id:int}
    /// Gets the user's details by given user id
    /// </summary>
    /// <param name="context"></param>
    private User GetUserDetails(HttpContext context, int userId)
    {
        return _userService.GetDetails(userId);
    }
    
    #endregion
}