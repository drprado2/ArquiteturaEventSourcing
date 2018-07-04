using ArquiteturaEventSourcing.Domain.Core.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Commands
{
    public abstract class Command : IValidator
    {
        public Command()
        {
            Id = Guid.NewGuid();
            Time = DateTime.Now.Ticks;
        }

        public Guid Id { get; private set; }

        public long Time { get; private set; }

        public string CommandSerialized { get; private set; }

        public void SetSerializationCommand(string jsonSerialization)
        {
            CommandSerialized = jsonSerialization;
        }

        public abstract void Execute();

        public abstract ValidationResult Validate();
    }
}
