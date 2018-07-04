using ArquiteturaEventSourcing.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Data
{
    public interface ICommandRepository
    {
        void Add(Command @command);

        void Commit();
    }
}
