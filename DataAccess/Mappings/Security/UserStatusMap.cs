using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class UserStatusMap : ClassMap<UserStatus>
    {
        public UserStatusMap()
        {
            Table("user_statuses");
            Id(u => u.Id, "id");
            Map(u => u.Name, "name");
        }
    }
}