using Microsoft.EntityFrameworkCore;
using Moq;
using PichinchaBank.Infrastructure.Persistence;
using PichinchaBank.Infrastructure.Repositories;

namespace PichinchaBank.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            var options = new DbContextOptionsBuilder<PichinchaBankDbContext>()
                .UseInMemoryDatabase(databaseName: $"PichinchaBankDbContext-{Guid.NewGuid()}")
                .Options;
            var mockStreamerDbContext = new PichinchaBankDbContext(options);
            mockStreamerDbContext.Database.EnsureDeleted();

            var mockUow = new Mock<UnitOfWork>(mockStreamerDbContext);
            return mockUow;
        }
    }
}
