using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Infra.DbContexts;

namespace ArquiteturaEventSourcing.Infra.Data
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly EventsContext _eventsContext;
        private readonly EntitiesContext _entitiesContext;

        public void Commit()
        {
            _eventsContext.SaveChanges();
            _entitiesContext.SaveChanges();
        }
    }
}
