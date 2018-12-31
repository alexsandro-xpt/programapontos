using System;
using ProgramaPontos.ReadModel.Participante;

namespace ProgramaPontos.ReadModel.Core
{
    public interface IParticipanteReadModelService
    {
        void InserirParticipanteReadModel(ParticipanteReadModel participanteReadModel);
        void AlterarNomeParticipante(Guid participanteId, string nome);
        ParticipanteReadModel RetornarParticipanteReadModelPeloEmail(string email);
        void AlterarEmailParticipante(Guid participanteId, string email);
    }
}