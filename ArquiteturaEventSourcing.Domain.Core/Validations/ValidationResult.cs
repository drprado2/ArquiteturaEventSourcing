using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Validations
{
    public class ValidationResult
    {
        private IList<ValidationError> _errors;

        public ValidationResult()
        {
            _errors = new List<ValidationError>();
        }

        public bool Success { get => !Errors.Any(); }

        public void AddError(ValidationError error)
        {
            _errors.Add(error);
        }

        public IList<ValidationError> Errors { get => _errors.ToList(); }
    }
}
