using System;

namespace Domain.Entities.Security
{
    public class RolesPerUsers
    {
        public virtual int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public virtual void AddRolePerUser(User user, Role role )
        {
            User = user;
            Role = role;
        }
    }
}