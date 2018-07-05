using ArquiteturaEventSourcing.Domain.Core.Commands;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.Mappings
{
    public class CommandMapping
    {
        public CommandMapping(ModelBuilder builder)
        {
            var customerMap = builder.Entity<CommandEntity>();

            customerMap.HasKey(x => x.Id);
            customerMap.Property(x => x.Time).IsRequired();
            customerMap.Property(x => x.CommandSerialized).IsRequired();
        }
    }
}
