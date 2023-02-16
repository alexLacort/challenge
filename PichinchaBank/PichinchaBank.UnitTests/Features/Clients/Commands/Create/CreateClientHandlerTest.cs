using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using PichinchaBank.Application.Features.Clients.Commands.Create;
using PichinchaBank.Application.Mappings;
using PichinchaBank.Infrastructure.Repositories;
using PichinchaBank.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PichinchaBank.UnitTests.Features.Clients.Commands.Create
{
    public class CreateClientHandlerTest
    {
        private readonly IMapper mapperTest;
        private readonly Mock<UnitOfWork> mockUow;
        private readonly Mock<ILogger<CreateClientHandler>> mockLogger;

        public CreateClientHandlerTest()
        {
            mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapperTest = mapperConfig.CreateMapper();
            mockLogger = new Mock<ILogger<CreateClientHandler>>();

            MockClientRepository.AddDataClientRepository(mockUow.Object.GetDataBaseContext);
        }

        [Fact]
        public async Task CreateClientHandler_CreateClientCommand_ReturnsNumber()
        {
            var inputTest = new CreateClientCommand
            {
                Name = "Test name streamer",
                Address = "Location",
                Identification = "test123",
                Password= "password",
                Gender = "Gender"
            };
            var handler = new CreateClientHandler(mockLogger.Object, mapperTest, mockUow.Object);
            var result = await handler.Handle(inputTest, CancellationToken.None);
            result.ShouldBeOfType<int>();
        }
    }
}
