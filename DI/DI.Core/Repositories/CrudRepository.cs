using System;
using System.Threading;
using DI.Core.Entities;

namespace DI.Core.Repositories
{
    public class CrudRepository<TEntity, TKey> : AbstractCrudRepository<TEntity, TKey>
        where TEntity : AbstractEntity<TKey>, new()
        where TKey : IComparable<TKey>, IEquatable<TKey>, new()
    {
        public override void OnBeforeCreate(TEntity entity)
        {
            Thread.Sleep(5000);
        }

        public override void OnBeforeUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}