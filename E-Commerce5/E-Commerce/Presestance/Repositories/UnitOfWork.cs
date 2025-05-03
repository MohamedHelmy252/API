using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entity;
using Presestance.Data;

namespace Presestance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        #region DbCall 
        private readonly StoreDbContext _storeDbContext;
        private readonly ConcurrentDictionary<string, object> _Repository;
        public UnitOfWork(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
            _Repository = new ConcurrentDictionary<string, object>();
        }
        #endregion



        public IGenericRepository<TEntity, TKey> GetGenericRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
           //Check If Repo Find In Dictionary , If Not Fount Create New And Return 
           var TypeName = typeof(TEntity).Name;//TKey
            if (_Repository.ContainsKey(TypeName))
            {
                return (IGenericRepository<TEntity, TKey>)_Repository[TypeName];
            }
            else
            {//If Not Fount Create New Repository
                var Repository = new GenericRepository<TEntity, TKey>(_storeDbContext);
                return Repository;  

            }

        }

        public async  Task<int> SaveChangesAsync()
        =>await _storeDbContext.SaveChangesAsync();
        
    }
}
