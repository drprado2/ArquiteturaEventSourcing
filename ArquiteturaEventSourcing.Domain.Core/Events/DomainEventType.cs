using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Events
{
    public enum DomainEventType
    {
        Creation = 0,
        Update = 1,
        Removal = 2
    }
}
