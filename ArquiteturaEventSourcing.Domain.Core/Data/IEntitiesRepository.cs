using ArquiteturaEventSourcing.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Core.Data
{
    public interface IEntitiesRepository<TEntity> where TEntity : Entity
    {
        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        List<TEntity> Get();

        TEntity GetById(Guid id);
    }
}
