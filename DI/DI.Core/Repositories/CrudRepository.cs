using System;
using System.Collections.Generic;
using System.Text;
using DI.Core.Contracts;
using DI.Core.Entities;

namespace DI.Core.Repositories
{
    public abstract class CrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TEntity : AbstractEntity<TKey>, new()
    {
        public virtual void Add(TEntity entity)
        {
            
        }
    }
}
