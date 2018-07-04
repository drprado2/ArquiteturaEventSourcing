using System;
using System.Collections.Generic;
using System.Linq;
using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Domain.Core.Entities;
using ArquiteturaEventSourcing.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ArquiteturaEventSourcing.Infra.Data
{
    public abstract class EntitiesRepository<TEntity> : IEntitiesRepository<TEntity> where TEntity : Entity
    {
        private readonly EntitiesContext _context;

        public EntitiesRepository(EntitiesContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public List<TEntity> Get()
        {
            return _context.Set<TEntity>().AsNoTracking().ToList();
        }

        public TEntity GetById(Guid id)
        {
            return _context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
