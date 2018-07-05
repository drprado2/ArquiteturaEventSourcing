using ArquiteturaEventSourcing.Domain.Core.Events;
using ArquiteturaEventSourcing.Domain.Users.Data;
using ArquiteturaEventSourcing.Domain.Users.Entities;

namespace ArquiteturaEventSourcing.Domain.Users.Events
{
    public class UserEventStream : IEventObserver
    {
        private readonly IUserRepository _repository;

        public UserEventStream(IUserRepository repository)
        {
            _repository = repository;
        }

        public void StreamCreateEvent(UserEvent @event)
        {
            var user = new User(@event.Name, @event.Password, @event.Email, @event.Login);
            _repository.Add(user);
        }

        public void StreamUpdateEvent(UserEvent @event)
        {
            var user = _repository.GetById(@event.Id);
            user.Update(@event.Name, @event.Password, @event.Email, @event.Login);
            _repository.Update(user);
        }

        public void StreamDeleteEvent(UserEvent @event)
        {
            var user = _repository.GetById(@event.Id);
            _repository.Delete(user);
        }

        public void Handle(DomainEvent @event)
        {
            var userEvent =  (UserEvent)@event;
            switch (userEvent.Type)
            {
                case (DomainEventType.Creation):
                    StreamCreateEvent(userEvent);
                    break;

                case (DomainEventType.Update):
                    StreamUpdateEvent(userEvent);
                    break;

                case (DomainEventType.Removal):
                    StreamDeleteEvent(userEvent);
                    break;
            }
        }
    }
}
