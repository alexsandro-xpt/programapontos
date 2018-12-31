using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Domain.Events
{
    public class ParticipanteEmailAlteradoDomainEvent : DomainEvent
    {
        public ParticipanteEmailAlteradoDomainEvent(Guid aggregateId, string email)
        {
            Email = email;
            AggregateId = aggregateId;
        }

        public string Email { get; }
    }
}
