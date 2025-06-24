using Events.Application.Events.Repositories;
using Events.Application.EventsTickets.Repositories;
using Events.Application.Users.Repositories;
using Events.Infrastructure.Events;
using Events.Infrastructure.EventsTickets;
using Events.Infrastructure.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IEventTicketRepository, EventTicketsRepository>();

            return services;
        }
    }
}
