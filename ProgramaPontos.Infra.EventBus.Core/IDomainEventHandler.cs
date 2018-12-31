using ProgramaPontos.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.EventHandler.Sinc
{
   public interface IDomainEventHandler<T>  
        where T : IDomainEvent 
 
    {
        void Handle(T @event);
    }
}
