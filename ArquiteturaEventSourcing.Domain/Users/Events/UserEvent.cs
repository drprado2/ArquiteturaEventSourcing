using ArquiteturaEventSourcing.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Users.Events
{
    public class UserEvent : DomainEvent
    {
        public UserEvent(DomainEventType type) : base(type)
        {
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
    }
}
