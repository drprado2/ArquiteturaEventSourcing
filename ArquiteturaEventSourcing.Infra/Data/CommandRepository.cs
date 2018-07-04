using ArquiteturaEventSourcing.Domain.Core.Commands;
using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.Data
{
    public class CommandRepository : ICommandRepository
    {
        private readonly CommandsContext _context;

        public CommandRepository(CommandsContext context)
        {
            _context = context;
        }

        public void Add(Command command)
        {
            _context.Add(command);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
