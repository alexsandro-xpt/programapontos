using MediatR;
using ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Domain.Services;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Handlers
{
    public class AlterarEmailParticipanteCommandHandler : IRequestHandler<AlterarEmailParticipanteCommand, ICommandResponse>
    {
        private readonly IParticipanteService participanteService;

        public AlterarEmailParticipanteCommandHandler(IParticipanteService participanteService)
        {
            this.participanteService = participanteService;
        }

        public Task<ICommandResponse> Handle(AlterarEmailParticipanteCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() => participanteService.AlterarEmail(command.ParticipanteId, command.Email));
        }




    }
}
