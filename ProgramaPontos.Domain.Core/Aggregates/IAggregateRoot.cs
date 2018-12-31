using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Domain.Core.Aggregates
{
    public interface IAggregateRoot
    {
        Guid Id { get;  }

        int? Version { get; }

        IEnumerable<IDomainEvent> GetUncommittedChanges() ;

        void MarkChangesAsCommitted();

        

        


    }
}
