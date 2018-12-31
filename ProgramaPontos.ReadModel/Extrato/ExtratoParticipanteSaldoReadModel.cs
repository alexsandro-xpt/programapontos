using ProgramaPontos.ReadModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.ReadModel.Extrato
{
    public class ExtratoParticipanteSaldoReadModel : IReadModel
    {
        public Guid Id { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid ExtratoId { get; set; }
        public int Saldo { get; set; }
    }
}
