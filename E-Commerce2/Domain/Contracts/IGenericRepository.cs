using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity,TKey> where TEntity : BaseEntity<TKey>
    {
        /// Get all entities
        Task<IEnumerable<TEntity>> GetAllAsync(bool TrackChanges=false);
        /// Get entity by id
        Task<TEntity?> GetByIdAsync(TKey key);
        /// Add entity
        Task AddAsync(TEntity entity);
        /// Update entity
        void Update(TEntity entity);
        /// Delete entity
        void Delete(TEntity entity);


    }
}
