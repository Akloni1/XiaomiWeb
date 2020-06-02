using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPhone.Entities
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime? ModifiedAt { get; set; }
    }
}
