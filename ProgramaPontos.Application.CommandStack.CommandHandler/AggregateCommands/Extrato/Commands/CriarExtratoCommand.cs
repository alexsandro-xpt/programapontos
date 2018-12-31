
using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands
{
    public class CriarExtratoCommand : Command, IRequest<ICommandResponse>
    {
        public CriarExtratoCommand(Guid extratoId, Guid participanteId)
        {
            ExtratoId = extratoId;
            ParticipanteId = participanteId;
        }

        public Guid ExtratoId { get; }
        public Guid ParticipanteId { get; }
    }
}
