using Events.Application.Events;
using Events.Application.Events.Repositories;
using Events.Application.EventsTickets;
using Events.Application.EventsTickets.Repositories;
using Events.Domain.Events;
using Events.Domain.EventsTickets;
using Events.Infrastructure;
using Events.Infrastructure.Events;
using Events.Infrastructure.EventsTickets;
using Events.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;
using WorkerService;

Console.WriteLine("Hello, World!");

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    await CreateHostBuilder(args).Build().RunAsync().ConfigureAwait(false);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application failed");
}
finally
{
    await Log.CloseAndFlushAsync();
}

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .ConfigureServices((hostContext, services) =>
    {
        services.AddScoped<BaseRepository<Event>, EventRepository>();
        services.AddScoped<BaseRepository<EventTickets>, EventTicketsRepository>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IEventTicketService, EventTicketService>();
        services.AddScoped<IEventTicketRepository, EventTicketsRepository>();
        services.Configure<ConnectionString>(hostContext.Configuration.GetSection(nameof(ConnectionString.DefaultConnection)));
        services.AddDbContext<EventsDbContext>(options =>
        options.UseSqlServer(hostContext.Configuration.GetConnectionString(nameof(ConnectionString.DefaultConnection))));
        services.AddHostedService<Worker>();
    })
    .UseSerilog();
