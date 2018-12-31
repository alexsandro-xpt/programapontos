
using MediatR;
using ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Handlers
{
    public class AlterarNomeParticipanteCommandHandler : IRequestHandler<AlterarNomeParticipanteCommand,ICommandResponse>
    {
        private readonly IParticipanteService participanteService;

        public AlterarNomeParticipanteCommandHandler(IParticipanteService participanteService)
        {
            this.participanteService = participanteService;
        }

        public Task<ICommandResponse> Handle(AlterarNomeParticipanteCommand command, CancellationToken cancellationToken)
        {
            return CommandHandlerHelper.ExecuteToResponse(() =>participanteService.AlterarNome(command.ParticipanteId, command.Nome));
        }

      
    }
}
