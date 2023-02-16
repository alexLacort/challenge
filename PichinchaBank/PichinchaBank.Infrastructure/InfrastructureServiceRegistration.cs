using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PichinchaBank.Application.Contracts.Persistence;
using PichinchaBank.Infrastructure.Persistence;
using PichinchaBank.Infrastructure.Repositories;

namespace PichinchaBank.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PichinchaBankDbContext>(o =>
                    o.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IPichinchaRepository<>), typeof(PichinchaRepository<>));

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<IBankTransactionRepository, BankTransactionRepository>();
            return services;
        }
    }
}
