using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public sealed class DomainEventBus
    {
        private List<DomainEvent> _events;
        private readonly DomainEventHandler _handler;

        public DomainEventBus(DomainEventHandler handler)
        {
            _events = new List<DomainEvent>();
            _handler = handler;
        }

        public void Dispatch()
        {
            _events.ForEach(x => _handler.Handle(x));
            _events.Clear();
        }

        public void AddEvent(DomainEvent @event)
        {
            _events.Add(@event);
        }
    }
}
