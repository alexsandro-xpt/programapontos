
using MediatR;
using ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Domain.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Handlers
{
    public class RemoverPontosExtratoCommandHandler : IRequestHandler<RemoverPontosExtratoCommand,ICommandResponse>
    {
        private readonly IExtratoService extratoService;

        public RemoverPontosExtratoCommandHandler(IExtratoService extratoService)
        {
            this.extratoService = extratoService;
        }

        public Task<ICommandResponse> Handle(RemoverPontosExtratoCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() => extratoService.RemoverPontos(command.ExtratoId, command.Pontos));
        }

    }
}
