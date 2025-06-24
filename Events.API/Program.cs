using Events.API.Infrastructure.Authentication;
using Events.API.Infrastructure.Extensions;
using Events.API.Infrastructure.Extensions.Swagger;
using Events.API.Infrastructure.SwaggerVersion;
using Events.Application.Extensions;
using Events.Domain.Users;
using Events.Infrastructure.Extensions;
using Events.Persistance.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


#region Serilog
builder.Logging.ClearProviders();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
#endregion

builder.Services.AddControllers();
builder.Services.AddApiVersioning(option =>
       option.AssumeDefaultVersionWhenUnspecified = true
);
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddVersionedApiExplorer(option =>
{
    option.GroupNameFormat = "'v'VVV";
    option.SubstituteApiVersionInUrl = true;
});

//services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<DarkRoastContext>().AddDefaultTokenProviders();


builder.Services.AddSwaggerocumentation();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerGenOptions>();


builder.Services.AddServices();
builder.Services.AddRepositories();

#region jwt
builder.Services.Configure<ConnectionString>(builder.Configuration.GetSection(nameof(ConnectionString)));
builder.Services.Configure<JWTConfiguration>(builder.Configuration.GetSection(nameof(JWTConfiguration)));
#endregion

builder.Services.AddHttpContextAccessor();

#region AddDbContext
builder.Services.AddDbContext<EventsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionString.DefaultConnection))));

builder.Services.AddScoped<DbContext, EventsDbContext>();

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<EventsDbContext>()
    .AddDefaultTokenProviders();
#endregion

#region HealthCheck
builder.Services.AddHealthChecks();
#endregion

builder.Services.AddTokenAuthentication(builder.Configuration.GetSection(nameof(JWTConfiguration)).GetSection(nameof(JWTConfiguration.Secret)).Value);

#region Authentication
builder.Services.AddAuthorization(opts =>
{
    opts.AddPolicy("User", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "User", "Moderator", "Admin");

    });
    opts.AddPolicy("Moderator", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "Moderator", "Admin");
    });
    opts.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Role", "Admin");
    });
});
#endregion


#region FluentValidation
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
#endregion

builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());

var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseGlobalExceptionMiddleware();
app.UseStaticFiles();

#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.InjectStylesheet("/SwaggerCustomize.css");
    foreach (var desciptions in provider.ApiVersionDescriptions)
    {
        c.SwaggerEndpoint($"/swagger/{desciptions.GroupName}/swagger.json"
            , $"{desciptions.GroupName.ToUpper()}");
    }

});
#endregion


app.UseHttpsRedirection();

app.UseRouting();
app.UseRequestResponseMiddleware();

#region Authorization
app.UseAuthentication();
app.UseAuthorization();
#endregion

app.UseRequestCulture();

app.MapControllers();
app.MapHealthChecks("/Healthz");

try
{
    Log.Information("Starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Terminated");
}
finally
{
    Log.CloseAndFlush();
}