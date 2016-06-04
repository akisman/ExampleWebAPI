using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PetService.Core.Repositories
{
    // Generic IRepository Interface
    // Repositories return IEnumerable instead of IQueryable, since the upper layers
    // shouldn't build queries. They encapsulate the queries. 
    public interface IRepository<TEntity> where TEntity : class
    {
        // Finding Objects
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // Adding Objects
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // Update Objects
        void Update(TEntity entity);

        // Removing Objects
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
