using AutoFixture;
using PichinchaBank.Domain;
using PichinchaBank.Infrastructure.Persistence;
using System.IO;

namespace PichinchaBank.UnitTests.Mocks
{
    public static class MockClientRepository
    {
        public static void AddDataClientRepository(PichinchaBankDbContext mockDbContext)
        {
            var fixture = new Fixture();

            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            //add custom client
            var mockClients = fixture.CreateMany<Client>().ToList();
            mockClients.Add(
                fixture.Build<Client>()
                .With(f => f.Identification, "cc12345")
                .With(f => f.Name, "Test create Client")
                .Without(f => f.Accounts)
                .Create());

            mockClients.Add(
                fixture.Build<Client>()
                .With(f => f.Identification, "cc98765")
                .Without(f => f.Accounts)
                .Create());

            mockDbContext.Clients.AddRange(mockClients);
            mockDbContext.SaveChanges();
        }

    }
}
