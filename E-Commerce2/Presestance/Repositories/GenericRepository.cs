using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Presestance.Data;

namespace Presestance.Repositories
{
    internal class GenericRepository<TEntity,TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly StoreDbContext _storeDbContext;

        public GenericRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
      
        }



        public async Task<IEnumerable<TEntity>> GetAllAsync(bool TrackChanges=false)
        =>TrackChanges? await _storeDbContext.Set<TEntity>().ToListAsync():
        await _storeDbContext.Set<TEntity>().AsNoTracking().ToListAsync();



        public async Task<TEntity?> GetByIdAsync(TKey key)
        => await _storeDbContext.Set<TEntity>().FindAsync(key);


        public async Task AddAsync(TEntity entity)
        => await _storeDbContext.Set<TEntity>().AddAsync(entity);

        public void Update(TEntity entity)
         =>  _storeDbContext.Set<TEntity>().Update(entity);


        public void Delete(TEntity entity)
        =>_storeDbContext.Set<TEntity>().Remove(entity);



        void IGenericRepository<TEntity, TKey>.Delete(TEntity entity)
       => _storeDbContext.Set<TEntity>().Remove(entity);


    }
    
}
