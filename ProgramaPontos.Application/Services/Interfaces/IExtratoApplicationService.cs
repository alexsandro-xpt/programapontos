using ProgramaPontos.ReadModel.Extrato;
using System;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.Services.Interfaces
{
    public interface IExtratoApplicationService
    {
        Task<Resultado> AdicionarPontosParticipante(Guid participanteId, int pontos);
        Task<Resultado> CriarExtratoParticipante(Guid extratoId, Guid participanteId);
        Task<Resultado> EfetuarQuebraPontosParticipante(Guid participanteId, int pontos);
        Task<Resultado> RemoverPontosParticipante(Guid participanteId, int pontos);
        Task<Resultado<ExtratoParticipanteReadModel>> RetornarExtratoParticipante(Guid participanteId);
        Task<Resultado<int>> RetornarSaldoParticipante(Guid participanteId);
    }
}