using ProgramaPontos.Domain.Core.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Domain.Core.Repository
{
   public interface IReadRepository<T> where T : IAggregateRoot
    {
        T GetById(Guid id);

    }
}
