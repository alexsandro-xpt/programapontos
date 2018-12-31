using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.InMemory.CommandBus.Testes
{
    public static class Extensions
    {
        public static IServiceCollection AddMockObject<T>(this IServiceCollection serviceCollection) 
            where T : class
        {
            serviceCollection.AddSingleton<T>((context) => new Moq.Mock<T>().Object);

            return serviceCollection;
        }
    }
}
