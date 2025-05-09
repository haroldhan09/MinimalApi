using Microsoft.AspNetCore.Http;
using MinimalApi.Users.Services;

namespace MinimalApi.Users.Api;

public sealed class UsersApi(IUserService userService)
{
    /// <summary>
    /// [GET]  /users/v1/details/{userId:int}
    /// Gets the user's details by id.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userId"></param>
    public IResult GetUserDetails(HttpContext context, int userId)
    {
        var details = userService.GetDetails(userId);
        return TypedResults.Ok(details);
    }
}