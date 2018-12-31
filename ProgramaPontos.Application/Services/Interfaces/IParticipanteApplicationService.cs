using System;
using System.Threading.Tasks;
using ProgramaPontos.Application.DTO;

namespace ProgramaPontos.Application.Services.Interfaces
{
    public interface IParticipanteApplicationService
    {
        Task<Resultado> AlterarEmailParticipante(Guid participanteId, string email);
        Task<Resultado> AlterarNomeParticipante(Guid participanteId, string nome);
        Task<Resultado> CriarParticipante(ParticipanteDTO participante);
        Task<Resultado<ParticipanteDTO>> RetornarParticipantePorEmail(string email);
    }
}