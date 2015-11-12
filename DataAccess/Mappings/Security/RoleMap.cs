using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table("roles");
            Id(r => r.Id, "id");
            Map(r => r.Name, "name");
            Map(r => r.Description, "description");
            Map(r => r.IsSysAdmin, "is_sysadmin");
        }
    }
}