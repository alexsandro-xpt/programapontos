

using ProgramaPontos.ReadModel.Core;
using System;
using System.Collections.Generic;

namespace ProgramaPontos.ReadModel.Extrato
{
    public class ExtratoParticipanteReadModel : IReadModel
    {
        public Guid ExratoId { get; set; }
        public Guid ParticipanteId { get; set; }
        public Guid Id { get; set; }
        public List<MovimentacaoExtratoReadModel> Movimentacoes { get; set; }
        

        public ExtratoParticipanteReadModel()
        {
            Movimentacoes = new List<MovimentacaoExtratoReadModel>();
        }
    }
}
