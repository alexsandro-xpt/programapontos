﻿using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace ProgramaPontos.Domain.Core.Aggregates
{
    public class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public int? Version { get; private set; }

        private readonly List<IDomainEvent> changes = new List<IDomainEvent>();

        protected AggregateRoot(IEnumerable<IDomainEvent> history)
        {
            if (history == null) return;
            foreach (var historyItem in history)
                ApplyChange(historyItem, false);

        }

        public IEnumerable<IDomainEvent> GetUncommittedChanges() => changes;
        public void MarkChangesAsCommitted()
        {
            changes.Clear();
        }

        protected void ApplyChange(IDomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(IDomainEvent @event, bool isNew)
        {
            if (@event.Version != 0) Version = @event.Version;
            InvokeApply(@event);
            if (isNew) changes.Add(@event);
        }


        private void InvokeApply(IDomainEvent @event)
        {

            MethodInfo method = this.GetType().GetMethod("Apply",BindingFlags.NonPublic | BindingFlags.Instance, Type.DefaultBinder, new Type[] { @event.GetType() }, null);

            if (method != null)
                method.Invoke(this, new[] { @event });


        }


    }
}
