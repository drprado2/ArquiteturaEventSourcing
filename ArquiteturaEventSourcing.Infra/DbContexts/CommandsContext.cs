using ArquiteturaEventSourcing.Domain.Core.Commands;
using ArquiteturaEventSourcing.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ArquiteturaEventSourcing.Infra.DbContexts
{
    public class CommandsContext : DbContext
    {
        public CommandsContext(DbContextOptions<CommandsContext> options) : base(options)
        {
        }

        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new CommandMapping(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
