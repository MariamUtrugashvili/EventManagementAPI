using Events.Application.Users.Requests;
using Events.Application.Users.Responses;
using Events.Domain.Users;

namespace Events.Application.Users
{
    public interface IUserService
    {
        Task<User> RegisterAsync(UserCreateModel user, CancellationToken cancellationToken);
        Task<User> AuthenticateAsync(UserLogInModel user, CancellationToken cancellationToken);
        Task<string> GetRoleAsync(string userId, CancellationToken cancellationToken);
        Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken);
    }
}
