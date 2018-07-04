using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.Data
{
    public class EventRepository : IEventRepository 
    {
        private readonly EventsContext _context;

        public EventRepository(EventsContext context)
        {
            _context = context;
        }

        public void Add<TEvent>(TEvent @event) where TEvent : DomainEvent
        {
            _context.Add<TEvent>(@event);
        }
    }
}
