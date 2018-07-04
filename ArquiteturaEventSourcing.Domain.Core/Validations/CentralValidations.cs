using System.Collections.Generic;
using System.Linq;

namespace ArquiteturaEventSourcing.Domain.Core.Validations
{
    public sealed class CentralValidations
    {
        public IList<ValidationError> Validations { get; private set; }

        public CentralValidations()
        {
            Validations = new List<ValidationError>();
        }

        public void AddValidation(ValidationError validation)
        {
            Validations.Add(validation);
        }

        public bool HasValidations()
        {
            return Validations.Any();
        }

        public IList<ValidationError> GetValidations()
        {
            return Validations.ToList();
        }

        public void Validate(IValidator validator)
        {
            var result = validator.Validate();

            if(!result.Success)
                foreach (var validation in result.Errors)
                    Validations.Add(validation);
        }
    }
}
