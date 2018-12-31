using ProgramaPontos.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.Commands.Extrato
{
    public class CriarExtratoParticipanteCommand : Command
    {
        public CriarExtratoParticipanteCommand(Guid participanteId)
        {
            ParticipanteId = participanteId;
        }

        public Guid ParticipanteId { get; }
    }
}
