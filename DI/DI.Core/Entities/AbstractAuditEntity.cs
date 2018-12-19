using System;
using System.Collections.Generic;
using System.Text;
using DI.Core.Contracts;

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

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public override bool Equals(IEntity<Guid> other)
        {
            return Id.Equals(other.Id);
        }

        /// <summary>Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.</summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>A value that indicates the relative order of the objects being compared. The return value has these meanings:
        ///  Value
        ///  Meaning
        ///  Less than zero
        ///  This instance precedes <paramref name="other">other</paramref> in the sort order.
        ///  Zero
        ///  This instance occurs in the same position in the sort order as <paramref name="other">other</paramref>.
        ///  Greater than zero
        ///  This instance follows <paramref name="other">other</paramref> in the sort order.
        /// </returns>
        public override int CompareTo(IEntity<Guid> other)
        {
            return Id.CompareTo(other.Id);
        }
    }
}
