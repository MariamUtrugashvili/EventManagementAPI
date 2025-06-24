using Events.Application.Users.Repositories;
using Events.Application.Users.Responses;
using Events.Domain.Enums;
using Events.Domain.Users;
using Events.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Events.Infrastructure.Users
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(EventsDbContext context) : base(context) { }

        #region Methods
        public async Task<User> AddAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);

            var roleId = await _context.Roles
                .Where(x => x.Name == RolesEnum.User.ToString())
                .Select(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var userRole = new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = roleId,
            };

            await _context.UserRoles.AddAsync(userRole, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return user;
        }

        public async Task<string> GetRoleAsync(string userId, CancellationToken cancellationToken)
        {
            var roleId = await _context.UserRoles
                .Where(x => x.UserId == userId)
                .Select(x => x.RoleId)
                .FirstOrDefaultAsync(cancellationToken);

            return await _context.Roles
                .Where(x => x.Id == roleId)
                .Select(x => x.Name)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<bool> ExistsUser(User user, CancellationToken cancellationToken)
        {
            return await _context.Users.AnyAsync(u => u.Id == user.Id, cancellationToken);
        }

        public async Task<User> GetAsync(User user, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(u => u.Email == user.Email, cancellationToken);
        }

        public async Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var roleId = await _context.Roles
                .Where(x => x.Name == RolesEnum.User.ToString())
                .Select(x => x.Id)
                .FirstOrDefaultAsync(cancellationToken);

            var userIds = await _context.UserRoles
                .Where(x => x.RoleId == roleId)
                .Select(x => x.UserId)
                .ToListAsync(cancellationToken);

            List<UserResponseModel> users = new List<UserResponseModel>();

            foreach (var userId in userIds)
            {
                var user = await _context.Users
                    .Where(x => x.Id == userId)
                    .Select(x => new UserResponseModel
                    {
                        ID = x.Id,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Email = x.Email
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                users.Add(user);
            }

            return users;
        }
        #endregion
    }
}
