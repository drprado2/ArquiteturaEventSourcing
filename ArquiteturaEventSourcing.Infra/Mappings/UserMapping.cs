using ArquiteturaEventSourcing.Domain.Users.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArquiteturaEventSourcing.Infra.Mappings
{
    public class UserMapping
    {
        public UserMapping(ModelBuilder builder)
        {
            var customerMap = builder.Entity<User>();

            customerMap.HasKey(x => x.Id);
            customerMap.Property(x => x.Name).HasMaxLength(200);
            customerMap.Property(x => x.Login).HasMaxLength(50);
            customerMap.Property(x => x.Password).HasMaxLength(50);
            customerMap.Property(x => x.Email).HasMaxLength(100);
        }
    }
}
