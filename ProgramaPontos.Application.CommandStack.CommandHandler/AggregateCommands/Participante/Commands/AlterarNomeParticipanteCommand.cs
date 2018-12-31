
using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands
{
    public class AlterarNomeParticipanteCommand : Command, IRequest<ICommandResponse>
    {
     

        public AlterarNomeParticipanteCommand(Guid participanteId, string nome)
        {
            ParticipanteId = participanteId;
            Nome = nome;
        }

        public Guid ParticipanteId { get; }
        public string Nome { get; }
    }
}