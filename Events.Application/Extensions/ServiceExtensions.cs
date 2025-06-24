using Events.Application.Events;
using Events.Application.EventsTickets;
using Events.Application.Users;
using Microsoft.Extensions.DependencyInjection;

namespace Events.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventTicketService, EventTicketService>();
            return services;
        }
    }
}
