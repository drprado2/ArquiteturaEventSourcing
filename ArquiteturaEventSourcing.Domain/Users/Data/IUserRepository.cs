using ArquiteturaEventSourcing.Domain.Core.Data;
using ArquiteturaEventSourcing.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Users.Data
{
    public interface IUserRepository : IEntitiesRepository<User>
    {
    }
}
