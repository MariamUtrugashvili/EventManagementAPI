using Events.Application.EventsTickets.Repositories;
using Events.Application.EventsTickets;
using Events.Application.EventsTickets.Requests;
using Events.Domain.EventsTickets;

namespace EventsDemo.Application.Tests.EventsTickets
{
    public class EventTicketServiceTests
    {
        private readonly Mock<IEventTicketRepository> _eventTicketRepo;
        private readonly Mock<IEventRepository> _eventRepo;

        private readonly EventTicketService _eventTicketService;

        public EventTicketServiceTests()
        {
            _eventTicketRepo = new Mock<IEventTicketRepository>();
            _eventRepo = new Mock<IEventRepository>();

            _eventTicketService = new EventTicketService(_eventTicketRepo.Object, _eventRepo.Object);
        }

        [Fact]
        public async Task Should_throw_exception_when_dependencies_are_null()
        {
            var eventTicketRepo = () => new EventTicketService(
                eventTicketRepo: null,
                eventRepo: _eventRepo.Object);

            var eventRepo = () => new EventTicketService(
                eventTicketRepo: _eventTicketRepo.Object,
                eventRepo: null);

            eventTicketRepo.Should().Throw<ArgumentNullException>();
            eventRepo.Should().Throw<ArgumentNullException>();
        }

        #region BookTicketAsync

        [Fact]
        public async Task BookTicketAsync_Should_throw_exception_when_repository_returns_false()
        {
            //Arrange
            _eventRepo.Setup(x => x.ExistsEvent(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            //Act
            var action = async () => await _eventTicketService.BookTicketAsync(new TicketRequestModel(), "Id", CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Not Found");
        }

        [Fact]
        public async Task BookTicketAsync_Should_throw_exception_when_repository_ExistsEvent_returns_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.ExistsEvent(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            _eventRepo.Setup(x => x.GetAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Event { TicketQuantity = 0 });

            //Act
            var action = async () => await _eventTicketService.BookTicketAsync(new TicketRequestModel(), "Id", CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Unfortunetely, theres no more tickets left");
        }

        [Theory]
        [InlineData(5)]
        public async Task BookTicketAsync_Should_create_ticket_and_update_event_database(int ticketQuantity)
        {
            //Arrange
            _eventRepo.Setup(x => x.ExistsEvent(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            var responseEvent = new Event { TicketQuantity = ticketQuantity };

            _eventRepo.Setup(x => x.GetAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseEvent);

            //Act
            await _eventTicketService.BookTicketAsync(new TicketRequestModel(), "Id", CancellationToken.None);

            //Assertions
            _eventTicketRepo.Verify(x => x.CreateTicketAsync(
                It.IsAny<EventTickets>(),
                It.IsAny<CancellationToken>()),
                Times.Once);

            responseEvent.TicketQuantity.Should().Be(ticketQuantity - 1);

            _eventRepo.Verify(x => x.UpdateAsync(
                It.IsAny<Event>(),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }

        #endregion

    }
}
