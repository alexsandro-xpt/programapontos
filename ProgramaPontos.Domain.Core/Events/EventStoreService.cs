using ProgramaPontos.Domain.Core.Aggregates;
using ProgramaPontos.Domain.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProgramaPontos.Domain.Core.Events
{
    public sealed class EventStoreService : IEventStoreService
    {
        private readonly IEventBus eventBus;
        private readonly IEventStore eventStore;

        public EventStoreService(IEventBus eventBus, IEventStore eventStore)
        {
            this.eventBus = eventBus;
            this.eventStore = eventStore;
        }

        public T LoadAggregate<T>(Guid aggregateId) where T: IAggregateRoot
        {
            var history = eventStore.GetEventsFromAggregate(aggregateId);
            return CreateAggregateFromHistory<T>(history);
        }

        private T CreateAggregateFromHistory<T>(IEnumerable<IDomainEvent> history)
        {
            return (T)typeof(T)
                 .GetConstructor(
                 BindingFlags.Instance | BindingFlags.NonPublic,
                 null, new Type[] { typeof(IEnumerable<IDomainEvent>) }, new ParameterModifier[0])
               .Invoke(new object[] { history });
        }

        public void SaveAggregate( IAggregateRoot aggregate)
        {
            var expectedVersion = aggregate.Version;

            //get aggregate version by id
            var version = eventStore.GetVersionByAggregate(aggregate.Id);
            
            //check consistency...
            if(version.HasValue && version != expectedVersion )
            {
                throw new ConsistencyException(aggregate.Id);
            }

            var newVersion = expectedVersion.HasValue ?  expectedVersion : 0;
            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                newVersion++;
                @event.Version = newVersion.Value;
                eventStore.Save(@event);
                eventBus.PublishEvent(@event);
            }

            aggregate.MarkChangesAsCommitted();
        }


    }
}
