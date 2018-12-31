using Microsoft.Extensions.DependencyInjection;

using ProgramaPontos.Application.CommandStack.CommandHandler.Participante;
using ProgramaPontos.Domain.Core.Events;
using ProgramaPontos.Domain.Repository;
using ProgramaPontos.Domain.Services;
using ProgramaPontos.Infra.EventStore.MongoDB;
using ProgramaPontos.Infra.InMemory.CommandBus;
using System;
using Xunit;

namespace ProgramaPontos.Infra.InMemory.CommandBus.Testes
{
    public class InMemoryCommandBusTest
    {
        [Fact]
        public void Test1()
        {
            var serviceProvider = new ServiceCollection()
                .AddMockObject<CriarParticipanteCommandHandler>()
                .AddMockObject<AlterarNomeParticipanteCommandHandler>()
                .AddMockObject<IParticipanteService>()
                .AddMockObject<IEventStore>()
                .AddMockObject<IParticipanteRepository>()
                .BuildServiceProvider();


            var bus = new InMemory.CommandBus.InMemoryCommandBus(serviceProvider);
            bus.SendCommand(new AlterarNomeParticipanteCommand(Guid.NewGuid(), "eu"));

        }
    }
}
