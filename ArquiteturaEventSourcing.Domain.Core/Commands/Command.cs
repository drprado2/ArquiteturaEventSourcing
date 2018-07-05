using ArquiteturaEventSourcing.Domain.Core.Validations;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Commands
{
    public abstract class Command : CommandEntity, IValidator
    {
        public abstract string Serialize();

        public abstract void Execute();

        public abstract ValidationResult Validate();
    }
}
