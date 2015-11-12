using System;

namespace Domain.Entities.Security
{
    public class RolesPerPrivileges
    {
        public virtual int Id { get; set; }
        public virtual Privilege Privilege { get; set; }
        public virtual Role Role { get; set; }

        public virtual void AddRolePerPrivilege(Role role, Privilege privilege)
        {
            Role = role;
            Privilege = privilege;
        }
    }
}