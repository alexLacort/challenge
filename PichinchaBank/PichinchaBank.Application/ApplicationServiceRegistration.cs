using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PichinchaBank.Application.Behaviours;
using PichinchaBank.Application.Contracts.Services;
using PichinchaBank.Application.Services;
using System.Reflection;


namespace PichinchaBank.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
            serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());

            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            serviceCollection.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));

            serviceCollection.AddScoped<IAccountManager, AccountManager>();
            serviceCollection.AddScoped<IClientManager, ClientManager>();
            serviceCollection.AddScoped<IBankTransactionManager, BankTransactionManager>();

            return serviceCollection;
        }

    }
}
