using ArquiteturaEventSourcing.Domain.Users.Data;
using ArquiteturaEventSourcing.Domain.Users.Entities;
using ArquiteturaEventSourcing.Infra.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Infra.Data
{
    public class UserRepository : EntitiesRepository<User>, IUserRepository
    {
        public UserRepository(EntitiesContext context) : base(context)
        {
        }
    }
}
