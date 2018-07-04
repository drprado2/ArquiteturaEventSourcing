using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Validations
{
    public interface IValidator
    {
        ValidationResult Validate();
    }
}
