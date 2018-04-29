using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFS.Core
{
    public abstract class AuditableEntity : BaseEntity
    {
        public int? CreatedByID { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public int? UpdatedByID { get; set; }
        public DateTime? UpdatedAt { get; protected set; }
        public AuditableEntity SetCreated()
        {
            this.CreatedAt = DateTime.Now;
            return this;
        }
        public AuditableEntity SetUpdate()
        {
            this.UpdatedAt = DateTime.Now;
            return this;
        }

    }
}

