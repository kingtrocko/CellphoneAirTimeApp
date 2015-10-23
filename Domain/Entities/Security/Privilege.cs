using System;

namespace Domain.Entities.Security
{
    public class Privilege
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }

    }
}
