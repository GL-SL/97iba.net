using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Core.Contracts
{
   public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
