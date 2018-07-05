using ArquiteturaEventSourcing.Domain.Core.Commands;
using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Domain.Core.Validations;
using ArquiteturaEventSourcing.Domain.Users.Data;
using ArquiteturaEventSourcing.Domain.Users.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Users.Commands
{
    public class CreateUserCommand : Command
    {
        private readonly IUserRepository _repository;
        private readonly CentralValidations _centralValidations;
        private readonly DomainEventBus _eventBus;

        public CreateUserCommand(
            string name,
            string password,
            string email,
            string login,
            IUserRepository repository,
            CentralValidations centralValidations,
            DomainEventBus eventBus)
        {
            _repository = repository;
            _centralValidations = centralValidations;
            eventBus = _eventBus;
        }

        [JsonProperty]
        public string Name { get; private set; }
        [JsonProperty]
        public string Password { get; private set; }
        [JsonProperty]
        public string Email { get; private set; }
        [JsonProperty]
        public string Login { get; private set; }

        public override void Execute()
        {
            if (_centralValidations.HasValidations())
                return;

            var newUserEvent = new UserEvent(DomainEventType.Creation)
            {
                Id = Guid.NewGuid(),
                Name = Name,
                Login = Login,
                Email = Email,
                Password = Password
            };

            _eventBus.AddEvent(newUserEvent);
        }

        public override string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override ValidationResult Validate()
        {
            var result = new ValidationResult();

            if (String.IsNullOrWhiteSpace(Name))
                result.AddError(new ValidationError("O nome é de preenchimento obrigatório"));

            if (String.IsNullOrWhiteSpace(Login))
                result.AddError(new ValidationError("O nome é de preenchimento obrigatório"));

            if (String.IsNullOrWhiteSpace(Password))
                result.AddError(new ValidationError("O nome é de preenchimento obrigatório"));

            return result;
        }
    }
}
