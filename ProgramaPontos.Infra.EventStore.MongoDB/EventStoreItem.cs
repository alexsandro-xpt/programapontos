using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProgramaPontos.Infra.EventStore.MongoDB
{
    class EventStoreItem
    {
        
        public string Id { get; internal set; }
        public string AggregateId { get; internal set; }
        public int  Version { get; internal set; }
        public string EventType { get; internal set; }
        public byte[] EventData { get; internal set; }
        public DateTime DateTime { get; internal set; }

            
       

        public static EventStoreItem FromDomainEvent(IDomainEvent @event)
        {
            return new EventStoreItem()
            {
                Id = Guid.NewGuid().ToString(),
                DateTime = @event.DateTime,
                AggregateId = @event.AggregateId.ToString(),
                Version = @event.Version,
                EventType = $"{@event.GetType().FullName}, {@event.GetType().Assembly.GetName().Name}",
                EventData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event))
            };
        }

        public static IDomainEvent ToDomainEvent(EventStoreItem eventStoreItem)
        {
            var type = Type.GetType(eventStoreItem.EventType);
            var json = Encoding.UTF8.GetString(eventStoreItem.EventData);
            return (IDomainEvent)JsonConvert.DeserializeObject(json, type);
        }
    }
}
