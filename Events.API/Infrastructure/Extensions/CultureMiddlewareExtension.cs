using Events.API.Infrastructure.Middlewares;

namespace Events.API.Infrastructure.Extensions
{
    static class CultureMiddlewareExtension
    {
        public static IApplicationBuilder UseRequestCulture(this IApplicationBuilder app)
        {
            return app.UseMiddleware<Culturemiddleware>();
        }
    }
}
