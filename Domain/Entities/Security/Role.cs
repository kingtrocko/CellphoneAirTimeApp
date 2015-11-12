using System;

namespace Domain.Entities.Security
{
    public class Role
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

        public virtual bool IsSysAdmin { get; set; }
    }
}
