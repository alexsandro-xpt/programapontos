using Bogus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Infra.Ioc.AspNetCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.Testes
{
   public abstract class TestsBase
    {
        protected IServiceProvider ServiceProvider;
        protected Faker Faker;

        public TestsBase()
        {
            var builder = new ConfigurationBuilder()
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddProgramaPontosServices( configuration);
            ServiceProvider = serviceCollection.BuildServiceProvider();
                                             Faker = new Faker();
        }
    }
}
