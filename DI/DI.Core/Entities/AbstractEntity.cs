using System;
using System.Collections.Generic;
using System.Text;
using DI.Core.Contracts;

namespace DI.Core.Entities
{
   public abstract class AbstractEntity<TKey> : IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
