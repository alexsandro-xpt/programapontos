using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Domain.Repository
{
    public interface IExtratoParticipanteRepository
    {
        bool ExisteExtratoParticipante(Guid id);
    }
}
