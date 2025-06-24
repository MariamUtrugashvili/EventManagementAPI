using Events.Domain.Localization;
using FluentValidation;
using System.Text.RegularExpressions;

namespace Events.API.Infrastructure.Extensions
{
    public static class UserValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> PhoneNumber<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(x => Regex.IsMatch(x, @"^5\d{8}$")).NotEmpty().WithMessage(Messages.Empty);
        }

        public static IRuleBuilderOptions<T, string> Email<T>(this IRuleBuilder<T, string> rule)
        {
            return rule.Must(x => Regex.IsMatch(x, @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$")).WithMessage(Messages.Email).NotEmpty().WithMessage(Messages.Empty);
        }
    }
}
