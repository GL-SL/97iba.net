using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DI.Core.Contracts;
using DI.Core.Entities;

namespace DI.Core.Repositories
{
    public abstract class AbstractCrudRepository<TEntity, TKey> : ICrudRepository<TEntity, TKey>
        where TEntity : AbstractEntity<TKey>, new()
        where TKey : IComparable<TKey>, IEquatable<TKey>, new()
    {
        private static readonly List<TEntity> _data = new List<TEntity>();
       
        public abstract void OnBeforeCreate(TEntity entity);
        public abstract void OnBeforeUpdate(TEntity entity);
        public virtual void Add(TEntity entity)
        {
            lock (_data)
            {
                if (_data.Any(x => x.Equals(entity))) return;
                OnBeforeCreate(entity);
                _data.Add(entity);
            }
      

            // X();
        }
    }
}
