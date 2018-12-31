using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Domain.Core.Events;
using ProgramaPontos.Infra.Bus.EventBusRabbitMQ.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.Bus.EventBusRabbitMQ
{
    public static class RabbitMQExtensions
    {
        public static IServiceCollection AddEventBusRabbitMQ(this IServiceCollection serviceCollection, IConfiguration configuration)
        {

            return serviceCollection.AddSingleton<IEventBus, RabbitMQEventBus>((context) =>
            {
                var settings = configuration.GetSection(nameof(RabbitMQSettings)).Get<RabbitMQSettings>();
                return new RabbitMQEventBus(settings);
            });


        }
    }
}
