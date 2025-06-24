using Events.Application.Events;
using Events.Application.Events.Responses;


namespace EventsDemo.Application.Tests.Events
{
    public class EventServiceTests
    {
        private readonly Mock<IEventRepository> _eventRepo;
        private readonly EventService _eventService;

        public EventServiceTests()
        {
            _eventRepo = new Mock<IEventRepository>();
            _eventService = new EventService(_eventRepo.Object);
        }

        [Fact]
        public async Task Should_throw_exception_when_dependency_is_null()
        {
            var eventRepo = () => new EventService(eventRepo: null);

            eventRepo.Should().Throw<ArgumentNullException>();
        }

        #region GetByIdAsync

        [Fact]
        public async Task GetByIdAsync_Should_throw_exception_when_repository_returns_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((Event)null);

            //Act
            var action = async () => await _eventService.GetByIdAsync(1, CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Event Was Not Found");
        }

        [Fact]
        public async Task GetByIdAsync_Should_throw_exception_when_repository_ExistsEvent_returns_false()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Event());

            _eventRepo.Setup(x => x.ExistsEvent(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            //Act
            var action = async () => await _eventService.GetByIdAsync(1, CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Event Id is incorrect");
        }

        [Fact]
        public async Task GetByIdAsync_Should_return_value_when_database_response_is_not_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new Event() { Id = 1 });

            _eventRepo.Setup(x => x.ExistsEvent(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(true);

            //Act
            var data = await _eventService.GetByIdAsync(1, CancellationToken.None);

            //Assertions
            using (new AssertionScope())
            {
                data.Should().NotBeNull();
                data.Should().BeOfType<EventResponseModel>();
                data.Id.Should().Be(1);
            }
        }

        #endregion

        #region GetAllAsync

        [Fact]
        public async Task GetAllAsync_Should_throw_exception_when_repository_returns_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetAllAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<Event>)null);

            //Act
            var action = async () => await _eventService.GetAllAsync(CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Something went wrong");
        }

        [Fact]
        public async Task GetAllAsync_Should_return_value_when_database_response_is_not_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetAllAsync(
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Event>() { new Event { Id = 1 } });

            //Act
            var data = await _eventService.GetAllAsync(CancellationToken.None);

            //Assertions
            using (new AssertionScope())
            {
                data.Should().NotBeNull();
                data.Should().BeOfType<List<AllEventResponseModel>>();
                data.FirstOrDefault().Id.Should().Be(1);
            }
        }

        #endregion

        #region GetUsersAllEventAsync

        [Fact]
        public async Task GetUsersAllEventAsync_Should_throw_exception_when_repository_returns_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetUsersAllEventsAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync((List<Event>)null);

            //Act
            var action = async () => await _eventService.GetUsersAllEventAsync("Id", CancellationToken.None);

            //Assertion
            await action.Should().ThrowAsync<Exception>().WithMessage("Not Found");
        }

        [Fact]
        public async Task GetUsersAllEventAsync_Should_return_value_when_database_response_is_not_null()
        {
            //Arrange
            _eventRepo.Setup(x => x.GetUsersAllEventsAsync(
                    It.IsAny<string>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<Event>() { new Event { Id = 1 } });

            //Act
            var data = await _eventService.GetUsersAllEventAsync("Id", CancellationToken.None);

            //Assertions
            using (new AssertionScope())
            {
                data.Should().NotBeNull();
                data.Should().BeOfType<List<EventResponseModel>>();
                data.FirstOrDefault().Id.Should().Be(1);
            }
        }

        #endregion
    }
}
