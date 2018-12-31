using System;
using System.Collections.Generic;
using System.Text;
using ProgramaPontos.ReadModel.Extrato;

namespace ProgramaPontos.ReadModel.Core
{
    public interface IExtratoReadModelService
    {
        Guid? RetornarIdExtrato(Guid participanteId);
        void InserirExtratoReadModel(ExtratoParticipanteReadModel extratoParticipanteReadModel);
        void AdicionarPontosExtrato(Guid extratoId, DateTime data, int pontos);
        void RemoverPontosExtrato(Guid extratoId, DateTime data, int pontos);
        void QuebraPontosExtrato(Guid extratoId, DateTime data, int pontos);
        ExtratoParticipanteReadModel RetornarExtrato(Guid extratoId);
        void AtualizarSaldoExtratoParticipante(Guid extratoId, int saldo);
        void InserirExtratoParticipanteSaldoReadModel(ExtratoParticipanteSaldoReadModel extratoParticipanteSaldoReadModel);
        int RetornarSaldoParticipante(Guid participanteId);
    }
}
