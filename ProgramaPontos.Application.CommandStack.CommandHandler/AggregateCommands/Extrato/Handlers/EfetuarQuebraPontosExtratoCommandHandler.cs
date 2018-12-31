
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
    public class EfetuarQuebraPontosExtratoCommandHandler : IRequestHandler<EfetuarQuebraPontosExtratoCommand, ICommandResponse>
    {
        private readonly IExtratoService extratoService;

        public EfetuarQuebraPontosExtratoCommandHandler(IExtratoService extratoService)
        {
            this.extratoService = extratoService;
        }

        public Task<ICommandResponse> Handle(EfetuarQuebraPontosExtratoCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() => extratoService.EfetuarQuebraPontos(command.ExtratoId, command.Pontos));
        }
    }
}
