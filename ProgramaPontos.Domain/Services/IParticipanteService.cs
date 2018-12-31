using System;

namespace ProgramaPontos.Domain.Services
{
    public interface IParticipanteService
    {
        void AdicionarParticipante(Guid id, string nome, string email);
        void AlterarNome(Guid id, string nome);
        void AlterarEmail(Guid id, string email);
    }
}