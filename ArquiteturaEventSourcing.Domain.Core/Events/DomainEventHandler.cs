using ArquiteturaEventSourcing.Domain.Core.Data;
using System;
using System.Collections.Generic;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public class DomainEventHandler
    {
        private Object _objLock = new Object();

        private readonly IEventRepository _eventRepository;

        private IDictionary<Type, List<Action<DomainEvent>>> _observers;

        public DomainEventHandler(IEventRepository eventRepository)
        {
            _observers = new Dictionary<Type, List<Action<DomainEvent>>>();
            _eventRepository = eventRepository;
        }

        public void AddObserver(DomainEvent @event, Action<DomainEvent> consumer)
        {
            lock (_objLock)
            {
                if (_observers[@event.GetType()] == null)
                    _observers.Add(@event.GetType(), new List<Action<DomainEvent>>());

                _observers[@event.GetType()].Add(consumer);
            }
        }

        public void Handle(DomainEvent @event)
        {
            _eventRepository.Add(@event);

            var observer = _observers[@event.GetType()];

            if(observer != null)
                observer.ForEach(consumer => consumer(@event));
        }
    }
}
