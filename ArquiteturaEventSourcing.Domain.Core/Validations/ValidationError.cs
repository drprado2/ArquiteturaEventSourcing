using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Validations
{
    public class ValidationError
    {
        public ValidationError(string error, string code = "")
        {
            Error = error;
            Code = code;
        }

        public string Error { get; private set; }
        public string Code { get; private set; }
    }
}
