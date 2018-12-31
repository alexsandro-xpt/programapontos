using ProgramaPontos.Domain.Core.Commands;
using System;

namespace ProgramaPontos.Application.Commands.Participante
{
    public class AlterarNomeParticipanteCommand : Command
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