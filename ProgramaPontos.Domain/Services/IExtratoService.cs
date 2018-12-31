using ProgramaPontos.Domain.Aggregates.ExtratoAggregate;
using System;

namespace ProgramaPontos.Domain.Services
{
    public interface IExtratoService
    {
        void AdicionarPontos(Guid extratoId, int pontos);
        void CriarExtrato(Guid extratoId, Guid participanteId);
        void EfetuarQuebraPontos(Guid extratoId, int pontos);
        void RemoverPontos(Guid extratoId, int pontos);
        Extrato RetornarExtrato(Guid extratoId);
     
    }
}