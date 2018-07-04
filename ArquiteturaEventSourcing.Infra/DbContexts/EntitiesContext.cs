using ArquiteturaEventSourcing.Domain.Users.Entities;
using ArquiteturaEventSourcing.Infra.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.DbContexts
{
    public class EntitiesContext : DbContext
    {
        public EntitiesContext(DbContextOptions<EntitiesContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new UserMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
