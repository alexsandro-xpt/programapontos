using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.EventStore.MongoDB
{
    public static class MongoDBExtensions
    {
        public static IServiceCollection AddMongoDBEventStore(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            
            return serviceCollection.AddSingleton<IEventStore, MongoDBEventStore>((context) =>           
            {
                var settings = configuration.GetSection(nameof(MongoDBEventStoreSettings)).Get<MongoDBEventStoreSettings>();
                return new MongoDBEventStore(settings);
            });
            


        }
    }
}
