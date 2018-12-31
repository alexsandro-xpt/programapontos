
using MediatR;
using ProgramaPontos.Application.CommandStack.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands
{
    public class CriarParticipanteCommand : Command, IRequest<ICommandResponse>
    {

        public CriarParticipanteCommand(Guid id, string nome,string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public Guid Id { get; }
        public string Nome { get; }
        public string Email { get; }
    }
}
