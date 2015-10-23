using System;
using System.Security.Cryptography;

namespace Domain.Entities.Security
{
    public class UserImage
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
        public virtual string Image { get; set; }
        public virtual string Size { get; set; }
        public virtual string Name { get; set; }

    }
}