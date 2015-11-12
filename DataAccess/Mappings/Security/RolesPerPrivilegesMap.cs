using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class RolesPerPrivilegesMap : ClassMap<RolesPerPrivileges>
    {
        public RolesPerPrivilegesMap()
        {
            Table("privileges_roles");
            Id(p => p.Id, "id");
            References(p => p.Privilege, "privilege_id");
            References(p => p.Role, "role_id");
        }
    }
}