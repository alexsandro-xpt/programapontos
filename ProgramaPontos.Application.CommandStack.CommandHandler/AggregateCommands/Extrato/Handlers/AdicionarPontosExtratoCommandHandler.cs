
using MediatR;
using ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Handlers
{
    public class AdicionarPontosExtratoCommandHandler : IRequestHandler<AdicionarPontosExtratoCommand, ICommandResponse>
    {
        private readonly IExtratoService extratoService;


        public AdicionarPontosExtratoCommandHandler(
            IExtratoService extratoService)
        {
            this.extratoService = extratoService;
        }

        public Task<ICommandResponse> Handle(AdicionarPontosExtratoCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() => extratoService.AdicionarPontos(command.ExtratoId, command.Pontos)          );

        }




    }
}
