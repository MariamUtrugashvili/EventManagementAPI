using Events.Application.Users.Responses;
using Events.Domain.Users;

namespace Events.Application.Users.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user, CancellationToken cancellationToken);
        Task<string> GetRoleAsync(string userId, CancellationToken cancellationToken);
        Task<User> GetAsync(User user, CancellationToken cancellationToken);
        Task<bool> ExistsUser(User user, CancellationToken cancellationToken);
        Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken);

    }
}
