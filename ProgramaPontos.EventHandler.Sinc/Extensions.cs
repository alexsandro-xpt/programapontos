﻿using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Domain.Events;
using ProgramaPontos.EventHandler.Sinc.Handlers.Extrato;
using ProgramaPontos.EventHandler.Sinc.Handlers.Participante;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.EventHandler.Sinc
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainEventHandlers(this IServiceCollection serviceCollection)
        {
           return serviceCollection
                 .AddScoped<IDomainEventHandler<ParticipanteCriadoDomainEvent>, ParticipanteCriadoDomainEventHandler>()
            .AddScoped<IDomainEventHandler<ParticipanteNomeAlteradoDomainEvent>, ParticipanteNomeAlteradoDomainEventHandler>()
            .AddScoped<IDomainEventHandler<ParticipanteEmailAlteradoDomainEvent>, ParticipanteEmailAlteradoDomainEventHandler>()
            .AddScoped<IDomainEventHandler<ExtratoCriadoDomainEvent>, ExtratoCriadoDomainEventHandler>()
            .AddScoped<IDomainEventHandler<ExtratoPontosAdicionadosDomainEvent>, ExtratoPontosHandler>()
            .AddScoped<IDomainEventHandler<ExtratoPontosRemovidosDomainEvent>, ExtratoPontosHandler>()
            .AddScoped<IDomainEventHandler<ExtratoQuebraAdicionadaDomainEvent>, ExtratoPontosHandler>()
            .AddScoped<IDomainEventHandler<ExtratoSaldoAtualizadoDomainEvent>, ExtratoSaldoAtualizadoDomainEventHandler>();
        }
    }
}
