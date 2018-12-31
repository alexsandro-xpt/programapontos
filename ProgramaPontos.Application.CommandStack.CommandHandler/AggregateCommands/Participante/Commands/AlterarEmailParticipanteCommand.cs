
using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands
{
    public class AlterarEmailParticipanteCommand : Command, IRequest<ICommandResponse>
    {
     

        public AlterarEmailParticipanteCommand(Guid participanteId, string email)
        {
            ParticipanteId = participanteId;
            Email= email;
        }

        public Guid ParticipanteId { get; }
        public string Email { get; }
    }
}