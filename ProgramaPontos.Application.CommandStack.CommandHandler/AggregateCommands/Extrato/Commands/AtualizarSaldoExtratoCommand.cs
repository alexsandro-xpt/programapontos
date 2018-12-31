using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands
{
    public class AtualizarSaldoExtratoCommand : Command, IRequest<ICommandResponse>
    {
        public AtualizarSaldoExtratoCommand(Guid ExtratoId)
        {
            this.ExtratoId = ExtratoId;
        }

        public Guid ExtratoId { get; }
    }
}
