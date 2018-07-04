using ArquiteturaEventSourcing.Domain.Users.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.Mappings
{
    public class UserEventMapping
    {
        public UserEventMapping(ModelBuilder builder)
        {
            var customerMap = builder.Entity<UserEvent>();

            customerMap.HasKey(x => x.EventId);
            customerMap.Property(x => x.Time).IsRequired();
            customerMap.Property(x => x.Type).IsRequired();
            customerMap.Property(x => x.Name).HasMaxLength(200);
            customerMap.Property(x => x.Password).HasMaxLength(200);
            customerMap.Property(x => x.Email).HasMaxLength(200);
            customerMap.Property(x => x.Login).HasMaxLength(200);
        }
    }
}
