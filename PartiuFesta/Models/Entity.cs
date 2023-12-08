using System;

namespace PartiuFesta.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { set; get; }
    }
}