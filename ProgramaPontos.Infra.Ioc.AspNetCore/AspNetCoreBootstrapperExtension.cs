﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProgramaPontos.Application.CommandStack.Bus;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Application.Services;
using ProgramaPontos.Application.Services.Interfaces;
using ProgramaPontos.Domain.Core.Events;
using ProgramaPontos.Domain.Repository;
using ProgramaPontos.Domain.Services;
using ProgramaPontos.Infra.Bus.EventBusRabbitMQ;
using ProgramaPontos.Infra.EventStore.MongoDB;
using ProgramaPontos.Infra.Repository;
using ProgramaPontos.ReadModel.Core;
using ProgramaPontos.ReadModel.ElasticSearch;
using ProgramaPontos.ReadModel.ElasticSearch.Extensions;
using ProgramaPontos.ReadModel.Extrato;

namespace ProgramaPontos.Infra.Ioc.AspNetCore
{
    public static class AspNetCoreBootstrapperExtension
    {
        public static IServiceCollection AddProgramaPontosServices(this IServiceCollection services,IConfiguration configuration)
        {

            #region  Application Services
            services
                .AddScoped<IExtratoApplicationService, ExtratoApplicationService>()
                .AddScoped<IParticipanteApplicationService, ParticipanteApplicationService>();

            #endregion

            #region Domain Services

            services
                .AddScoped<IExtratoService, ExtratoService>()
                .AddScoped<IParticipanteService, ParticipanteService>();


            #endregion

            #region Commands
            services
                .AddScoped<ICommandBus, CommandBus>();
            #endregion

            #region EventStore
            services
                .AddSingleton<IEventStoreService, EventStoreService>()
                .AddMongoDBEventStore(configuration);

            #endregion

            #region Bus
            services.AddEventBusRabbitMQ(configuration);
            #endregion

            #region ReadModel
            services
                .AddScoped<IExtratoReadModelService, ExtratoReadModelService>()
                .AddScoped<IParticipanteReadModelService, ParticipanteReadModelService>()
                .AddElasticSearch(configuration);
            #endregion

            #region MediatR
            services.AddMediatR();
            #endregion

            #region Repository
            services
                .AddScoped<IExtratoParticipanteRepository, ExtratoParticipanteRepository>();

            #endregion

            return services;
        }

    }
}
