using ProgramaPontos.Domain.Repository;
using ProgramaPontos.ReadModel.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.Repository
{
    public class ExtratoParticipanteRepository : IExtratoParticipanteRepository
    {
        private readonly IExtratoReadModelService extratoParticipanteReadModelService;

        public ExtratoParticipanteRepository(IExtratoReadModelService extratoParticipanteReadModelService)
        {
            this.extratoParticipanteReadModelService = extratoParticipanteReadModelService;
        }

        public bool ExisteExtratoParticipante(Guid participanteId)
        {
            return extratoParticipanteReadModelService.RetornarIdExtrato(participanteId).HasValue;
        }
    }
}
