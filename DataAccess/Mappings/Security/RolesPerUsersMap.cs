using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class RolesPerUsersMap : ClassMap<RolesPerUsers>
    {
        public RolesPerUsersMap()
        {
            Table("roles_users");
            Id(r => r.Id, "id");
            References(r => r.Role).Column("role_id");
            References(r => r.User, "user_id");
        }
    }
}