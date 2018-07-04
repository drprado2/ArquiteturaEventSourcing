using ArquiteturaEventSourcing.Domain.Users.Events;
using ArquiteturaEventSourcing.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.DbContexts
{
    public class EventsContext : DbContext
    {
        public EventsContext(DbContextOptions<EventsContext> options) : base(options)
        {
        }

        public DbSet<UserEvent> UserEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserEventMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
