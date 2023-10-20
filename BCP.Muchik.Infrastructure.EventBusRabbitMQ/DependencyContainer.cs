using BCP.Muchik.Infrastructure.EventBus.Interfaces;
using BCP.Muchik.Infrastructure.EventBusRabbitMQ.Settings;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace BCP.Muchik.Infrastructure.EventBusRabbitMQ
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterRabbitServices(this IServiceCollection services, IConfiguration configuration)
        {
            //MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            //Event Bus
            services.AddSingleton<IEventBus, RabbitMqBus>(config =>
            {
                var mediatorFactory = config.GetService<IMediator>();
                var scopeFactory = config.GetRequiredService<IServiceScopeFactory>();
                var optionsFactory = config.GetService<IOptions<RabbitMqSettings>>();
                return new RabbitMqBus(mediatorFactory, scopeFactory, optionsFactory);
            });

            return services;
        }
    }
}
