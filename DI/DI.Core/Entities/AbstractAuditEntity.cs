using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Core.Entities
{
    public abstract class AbstractAuditEntity : AbstractEntity<Guid>
    {
        public AbstractAuditEntity()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTimeOffset.Now;
            UpdatedAt = DateTimeOffset.Now;
        }

        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
