using ArquiteturaEventSourcing.Domain.Core.Commands;
using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Domain.Users.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain
{
    public class DomainStartup
    {
        private readonly DomainEventHandler _domainEventHandler;
        private readonly UserEventStream _userEventStream;

        public DomainStartup(DomainEventHandler domainEventHandler, UserEventStream userEventStream)
        {
            _domainEventHandler = domainEventHandler;
            _userEventStream = userEventStream;
        }

        public void Start()
        {
            _domainEventHandler.AddObserver<UserEvent>(_userEventStream);
        }
    }
}
