using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Domain.Core.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly CentralValidations _validator;
        private readonly ICommandRepository _commandRepository;
        private readonly IUnityOfWork _uoW;
        private readonly DomainEventBus _eventBus;

        public CommandHandler(CentralValidations validator, IUnityOfWork unityOfWork, ICommandRepository commandRepository, DomainEventBus eventBus)
        {
            _validator = validator;
            _uoW = unityOfWork;
            _commandRepository = commandRepository;
            _eventBus = eventBus;
        }

        public void Handle(Command command)
        {
            _commandRepository.Add(command);
            _commandRepository.Commit();

            _validator.Validate(command);

            command.Execute();

            if (!_validator.HasValidations())
            {
                _eventBus.Dispatch();
                _uoW.Commit();
            }
        }
    }
}
