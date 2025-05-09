using MinimalApi.Users.Models;

namespace MinimalApi.Users.Services;

public interface IUserService
{
    User GetDetails(int userId);
}