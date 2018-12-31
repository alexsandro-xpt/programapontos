using MediatR;
using ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Handlers
{
    public class CriarExtratoExtratoCommandHandler : IRequestHandler<CriarExtratoCommand, ICommandResponse>
    {
        private readonly IExtratoService extratoService;

        public CriarExtratoExtratoCommandHandler(IExtratoService extratoService)
        {
            this.extratoService = extratoService;
        }

        public Task<ICommandResponse> Handle(CriarExtratoCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() => extratoService.CriarExtrato(command.ExtratoId, command.ParticipanteId));

        }
    }
}
