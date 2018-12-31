using System;

namespace ProgramaPontos.Domain.Core.Events
{
    public class DomainEvent : IDomainEvent
    {
        public int Version { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
        public Guid AggregateId { get; set; }
    }
}
