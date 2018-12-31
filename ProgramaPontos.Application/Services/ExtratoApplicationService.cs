
using ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Application.Extensions;
using ProgramaPontos.Application.Services.Interfaces;
using ProgramaPontos.ReadModel.Core;
using ProgramaPontos.ReadModel.Extrato;
using System;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.Services
{
    public class ExtratoApplicationService : IExtratoApplicationService
    {
        private readonly ICommandBus commandBus;
        private readonly IExtratoReadModelService extratoReadModelService;

        public ExtratoApplicationService(ICommandBus commandBus, IExtratoReadModelService extratoReadModelService)
        {
            this.commandBus = commandBus;
            this.extratoReadModelService = extratoReadModelService;
        }

        public Task<Resultado> AdicionarPontosParticipante(Guid participanteId, int pontos)
        {

            var extratoId = RetornarExtratoComExcecaoSeNulo(participanteId);
            return commandBus.EnviarCommandoRetornaResultadoAsync(new AdicionarPontosExtratoCommand(extratoId, pontos));
        }



        public Task<Resultado> RemoverPontosParticipante(Guid participanteId, int pontos)
        {
            var extratoId = RetornarExtratoComExcecaoSeNulo(participanteId);
            return commandBus.EnviarCommandoRetornaResultadoAsync(new RemoverPontosExtratoCommand(extratoId, pontos));
        }

        public Task<Resultado> EfetuarQuebraPontosParticipante(Guid participanteId, int pontos)
        {
            var extratoId = RetornarExtratoComExcecaoSeNulo(participanteId);
            return commandBus.EnviarCommandoRetornaResultadoAsync(new EfetuarQuebraPontosExtratoCommand(extratoId, pontos));
        }

        public Task<Resultado> CriarExtratoParticipante(Guid extratoId, Guid participanteId)
        {
            return commandBus.EnviarCommandoRetornaResultadoAsync(new CriarExtratoCommand(extratoId, participanteId));
        }


        public Task<Resultado<ExtratoParticipanteReadModel>> RetornarExtratoParticipante(Guid participanteId)
        {
            return Task.Run<Resultado<ExtratoParticipanteReadModel>>(() =>
             {

                 try
                 {
                     var extratoId = RetornarExtratoComExcecaoSeNulo(participanteId);
                     return new Resultado<ExtratoParticipanteReadModel>(extratoReadModelService.RetornarExtrato(extratoId));

                 }
                 catch (Exception ex)
                 {
                     return new Resultado<ExtratoParticipanteReadModel>(ex);

                 }

             });

        }
        private Guid RetornarExtratoComExcecaoSeNulo(Guid participanteId)
        {
            var extratoId = extratoReadModelService.RetornarIdExtrato(participanteId);

            if (!extratoId.HasValue)
                throw new InvalidOperationException($"O extrato {extratoId} não existe.");
            return extratoId.Value;
        }

        public Task<Resultado<int>> RetornarSaldoParticipante(Guid participanteId)
        {
            return Task.Run(()=> 
            {
                return new Resultado<int>( extratoReadModelService.RetornarSaldoParticipante(participanteId));
            } );
        }
    }
}
