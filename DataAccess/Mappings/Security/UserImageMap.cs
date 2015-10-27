using Domain.Entities.Security;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

namespace DataAccess.Mappings.Security
{
    public class UserImageMap : ClassMap<UserImage>
    {
        public UserImageMap()
        {
            Table("user_image");
            Id(i => i.Id, "id");
            Map(i => i.Type, "type");
            Map(i => i.Image, "image");
            Map(i => i.Size, "size");
            Map(i => i.Name, "name");


        }
    }
}