using Domain.Entities.Security;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("users");
            Id(u => u.Id).Column("id");
            Map(u => u.FirstName, "first_name");
            Map(u => u.LastName, "last_name");
            Map(u => u.Address1, "address1");
            Map(u => u.Address2, "address2");
            Map(u => u.PhoneNumber, "phone_number");
            Map(u => u.Email, "email");
            Map(u => u.UserName, "username");
            Map(u => u.Password, "password");
            References(u => u.UserStatus).Column("status_id");
        }
    }
}