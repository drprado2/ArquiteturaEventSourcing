using ArquiteturaEventSourcing.Domain.Core.Data;
using System;
using System.Collections.Generic;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public class DomainEventHandler
    {
        private Object _objLock = new Object();

        private readonly IEventRepository _eventRepository;

        private IDictionary<Type, List<IEventObserver>> _observers;

        public DomainEventHandler(IEventRepository eventRepository)
        {
            _observers = new Dictionary<Type, List<IEventObserver>>();
            _eventRepository = eventRepository;
        }

        public void AddObserver<TEvent>(IEventObserver consumer) where TEvent : DomainEvent
        {
            lock (_objLock)
            {
                if (!_observers.ContainsKey(typeof(TEvent)))
                    _observers.Add(typeof(TEvent), new List<IEventObserver>());

                _observers[typeof(TEvent)].Add(consumer);
            }
        }

        public void Handle(DomainEvent @event)
        {
            _eventRepository.Add(@event);

            var observer = _observers[@event.GetType()];

            if(observer != null)
                observer.ForEach(consumer => consumer.Handle(@event));
        }
    }
}
