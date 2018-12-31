
using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Extrato.Commands
{
    public class AdicionarPontosExtratoCommand : Command, IRequest<ICommandResponse>
    {
        public AdicionarPontosExtratoCommand(
            Guid extratoId,
            int pontos)
        {
            ExtratoId = extratoId;
            Pontos = pontos;
        }

        public Guid ExtratoId { get; }
        public int Pontos { get; }
    }
}
