using System;
using System.Collections.Generic;
using System.Text;
using DI.Core.Contracts;

namespace DI.Core.Entities
{
   public class Task : AbstractAuditEntity
    {
        public string Name { get; set; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.</returns>
        public override bool Equals(IEntity<Guid> other)
        {
            return (other as Task)?.Name == Name;
        }

        /// <summary>Returns a string that represents the current object.</summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
