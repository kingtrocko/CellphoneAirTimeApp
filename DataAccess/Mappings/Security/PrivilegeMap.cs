using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class PrivilegeMap : ClassMap<Privilege>
    {
        public PrivilegeMap()
        {
            Table("privileges");
            Id(p => p.Id, "id");
            Map(p => p.Name, "name");
            Map(p => p.Description, "description");
        }
    }
}