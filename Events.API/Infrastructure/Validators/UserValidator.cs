using Events.API.Infrastructure.Extensions;
using Events.Application.Users.Requests;
using Events.Domain.Localization;
using FluentValidation;

namespace Events.API.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserCreateModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.PasswordHash.Length)
                        .NotEmpty()
                        .WithMessage(Messages.Empty)
                        .ExclusiveBetween(8, 40)
                        .WithMessage(Messages.Password);

            RuleFor(x => x.Email).Email();

            RuleFor(x => x.FirstName.Length)
                        .NotEmpty()
                        .WithMessage(Messages.Empty)
                        .ExclusiveBetween(2, 40)
                        .WithMessage(Messages.Firstname);

            RuleFor(x => x.LastName.Length)
                .NotEmpty()
                .ExclusiveBetween(2, 60)
                .WithMessage(Messages.Lastname);

            RuleFor(x => x.PhoneNumber).PhoneNumber();
        }
    }
}
