using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public abstract class DomainEvent
    {
        public DomainEvent(DomainEventType type)
        {
            EventId = Guid.NewGuid();
            Time = DateTime.Now.Ticks;
            Type = type;
        }

        public Guid EventId { get; private set; }

        public long Time { get; private set; }

        public DomainEventType Type { get; private set; }
    }
}
