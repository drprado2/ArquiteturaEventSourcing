using ArquiteturaEventSourcing.Domain.Core.Entities;
using ArquiteturaEventSourcing.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArquiteturaEventSourcing.Domain.Users.Entities
{
    public class User : Entity
    {
        public User(string name, string password, string email, string login)
        {
            Name = name;
            Password = password;
            Email = email;
            Login = login;
        }

        public void Update(string name, string password, string email, string login)
        {
            Name = name;
            Password = password;
            Email = email;
            Login = login;
        }

        public string Name { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public string Login { get; private set; }
    }
}
