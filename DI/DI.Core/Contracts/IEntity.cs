using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Core.Contracts
{
   public interface IEntity<TKey> : IEquatable<IEntity<TKey>>, IComparable<IEntity<TKey>>
       where TKey : IComparable<TKey>, IEquatable<TKey>, new()
    {
        TKey Id { get; set; }
    }
}
