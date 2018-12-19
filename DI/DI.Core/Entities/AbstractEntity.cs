using System;
using System.Collections.Generic;
using System.Text;
using DI.Core.Contracts;

namespace DI.Core.Entities
{
   public abstract class AbstractEntity<TKey> : IEntity<TKey>
       where TKey : IComparable<TKey>, IEquatable<TKey>, new()
    {
        public TKey Id { get; set; }


       public abstract bool Equals(IEntity<TKey> other);

        public abstract int CompareTo(IEntity<TKey> other);
    }
}
