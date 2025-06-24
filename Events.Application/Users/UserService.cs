using Events.Application.Users.Repositories;
using Events.Application.Users.Requests;
using Events.Application.Users.Responses;
using Events.Domain.Exceptions;
using Events.Domain.Localization.ExceptionMessages;
using Events.Domain.Users;
using Mapster;

namespace Events.Application.Users
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _repository;

        #region ctor
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        public async Task<User> AuthenticateAsync(UserLogInModel user, CancellationToken cancellationToken)
        {
            user.PasswordHash = CustomHasher.GenerateHash(user.PasswordHash);

            var result = await _repository.GetAsync(user.Adapt<User>(), cancellationToken);
            if (result == null)
                throw new ItemNotFoundException(ErrorMessages.UserNotFound);

            return result;
        }

        public async Task<string> GetRoleAsync(string userId, CancellationToken cancellationToken)
        {
            return await _repository.GetRoleAsync(userId, cancellationToken);
        }

        public async Task<User> RegisterAsync(UserCreateModel user, CancellationToken cancellationToken)
        {
            user.PasswordHash = CustomHasher.GenerateHash(user.PasswordHash);

            var entity = user.Adapt<User>();
            if (await _repository.ExistsUser(entity, cancellationToken))
                throw new InvalidAccount(ErrorMessages.AlreadyExists);

            entity.NormalizedEmail = user.Email.ToUpper();
            entity.NormalizedUserName = user.Email.ToUpper();
            entity.UserName = user.Email;
            return await _repository.AddAsync(entity, cancellationToken);
        }

        public async Task<List<UserResponseModel>> GetAllUsersAsync(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllUsersAsync(cancellationToken);
            if (result == null)
                throw new InvalidOperation(ErrorMessages.Invalid);
            return result;
        }

        #endregion
    }
}
