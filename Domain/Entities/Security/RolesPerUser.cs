using System;

namespace Domain.Entities.Security
{
    public class RolesPerUser
    {
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }

        public virtual void AddRolePerUser(User user, Role role )
        {
            User = user;
            Role = role;
        }
    }
}