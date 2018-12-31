using ProgramaPontos.ReadModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.ReadModel.Participante
{
    public class ParticipanteReadModel : IReadModel

    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
