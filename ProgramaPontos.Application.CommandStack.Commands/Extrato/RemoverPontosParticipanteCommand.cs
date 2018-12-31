using ProgramaPontos.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.Commands.Extrato
{
    public class RemoverPontosParticipanteCommand : Command
    {
        public RemoverPontosParticipanteCommand(Guid participanteId, int pontos)
        {
            ParticipanteId = participanteId;
            Pontos = pontos;
        }

        public Guid ParticipanteId { get; }
        public int Pontos { get; }
    }
}
