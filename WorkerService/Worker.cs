using Events.Application.Events;
using Events.Application.EventsTickets;
using NCrontab;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        //   private readonly IEventService _eventService;
        private CrontabSchedule _schedule;
        private DateTime _nextRun;

        private string Schedule => "*/5 * * * * *"; //Runs every 5 seconds
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _schedule = CrontabSchedule.Parse(Schedule, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
            _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            // _eventService = eventService;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            do
            {
                var now = DateTime.Now;
                _schedule.GetNextOccurrence(now);
                if (now > _nextRun)
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var service = scope.ServiceProvider.GetRequiredService<IEventService>();
                        var tktservice = scope.ServiceProvider.GetRequiredService<IEventTicketService>();

                        await service.CheckEventsEndTime(stoppingToken);
                        await tktservice.CheckTicketsReservationTime(stoppingToken);
                    }
                    _nextRun = _schedule.GetNextOccurrence(DateTime.Now);

                }
            }
            while (!stoppingToken.IsCancellationRequested);
        }
    }
}