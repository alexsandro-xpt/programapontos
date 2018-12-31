using ProgramaPontos.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Application.Commands.Participante
{
    public class CriarParticipanteCommand : Command
    {
        public CriarParticipanteCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; }
        public string Nome { get; }
    }
}
