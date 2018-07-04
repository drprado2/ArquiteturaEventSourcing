using ArquiteturaEventSourcing.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Data
{
    public interface IEventRepository
    {
        void Add<TEvent>(TEvent @event) where TEvent : DomainEvent;
    }
}
