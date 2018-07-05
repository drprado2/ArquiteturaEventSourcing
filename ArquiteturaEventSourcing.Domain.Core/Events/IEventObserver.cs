using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public interface IEventObserver
    {
        void Handle(DomainEvent @event);
    }
}
