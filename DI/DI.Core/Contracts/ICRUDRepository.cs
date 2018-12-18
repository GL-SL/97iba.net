using System;
using System.Collections.Generic;
using System.Text;

namespace DI.Core.Contracts
{
   public interface ICrudRepository<in TEntity, TKey> where TEntity:IEntity<TKey>, new()
   {
       void Add(TEntity entity);
   }
}
