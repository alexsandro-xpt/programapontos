using System;

namespace ProgramaPontos.Domain.Core.Events
{
    public interface IDomainEvent
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
        DateTime DateTime { get; set; }

    }
}
