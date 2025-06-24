using System.Globalization;

namespace Events.API.Infrastructure.Middlewares
{
    public class Culturemiddleware
    {
        private readonly RequestDelegate _next;

        public Culturemiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var Name = "en-US";

            var query = context.Request.Headers["Accept-Language"].ToString();

            if (!string.IsNullOrWhiteSpace(query))
                Name = query.Split(',')[0];

            var culture = new CultureInfo(Name);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await _next(context);
        }
    }
}
