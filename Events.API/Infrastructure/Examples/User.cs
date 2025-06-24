using Events.Application.Users.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace Events.API.Infrastructure.Examples
{
    public class User
    {
        public class UserAuthorizationExamples : IMultipleExamplesProvider<UserCreateModel>
        {
            public IEnumerable<SwaggerExample<UserCreateModel>> GetExamples()
            {
                yield return SwaggerExample.Create("example 1", new UserCreateModel
                {
                    Email = "Mariami@gmail.com",
                    FirstName = "Mariam",
                    LastName = "Utrugashvili",
                    PhoneNumber = "555212121",
                    PasswordHash = "Mariami_1"
                });

                yield return SwaggerExample.Create("example 2", new UserCreateModel
                {
                    Email = "Lashuti@gmail.com",
                    FirstName = "Lasha",
                    LastName = "Goginava",
                    PhoneNumber = "555313131",
                    PasswordHash = "Mariami_1"
                });
            }
        }
    }
}
