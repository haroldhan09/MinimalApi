using MinimalApi.Users.Models;

namespace MinimalApi.Users.Services;

public class UserService : IUserService
{
    public User GetDetails(int userId)
    {
        return new User()
        {
            FirstName = "Test",
            LastName = "User",
            Username = "BlueHourGames"
        };
    }
}
