using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using PichinchaBank.Application.Features.Clients.Commands.Update;
using PichinchaBank.Application.Mappings;
using PichinchaBank.Infrastructure.Repositories;
using PichinchaBank.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace PichinchaBank.UnitTests.Features.Clients.Commands.Update
{
    public class UpdateClientHandlerTest
    {
        private readonly IMapper mapperTest;
        private readonly Mock<UnitOfWork> mockUow;
        private readonly Mock<ILogger<UpdateClientHandler>> mockLogger;

        public UpdateClientHandlerTest()
        {
            mockUow = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            mapperTest = mapperConfig.CreateMapper();
            mockLogger = new Mock<ILogger<UpdateClientHandler>>();
            MockClientRepository.AddDataClientRepository(mockUow.Object.GetDataBaseContext);
        }

        [Fact]
        public async Task UpdateStreamerHandler_UpdateStreamerCommand_ReturnsUnit()
        {
            var inputTest = new UpdateClientCommand
            {
                Identification = "cc12345",
                Name = "Field modify",
            };
            var handler = new UpdateClientHandler(mockUow.Object, mapperTest, mockLogger.Object);
            var result = await handler.Handle(inputTest, CancellationToken.None);
            result.ShouldBeOfType<Unit>();
        }
    }
}
