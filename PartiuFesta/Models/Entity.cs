using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PartiuFesta.Models {
    public abstract class Entity  {

        protected Entity() {

            Id= Guid.NewGuid();

        }

        public Guid Id { set; get; }

    }
}
