using ATG.Data.Models;
using ATG.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATG.Repositories
{

    public abstract class GenericRepository<TContext, T> : IGenericRepository<TContext, T>
   where TContext : DbContext
   where T : class
    {

        #region Fields
        public TContext _db { get; private set; }
        //internal ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        #endregion
        #region Constructors
        protected GenericRepository() //: this(new ApplicationDbContext())
        {

        }

        protected GenericRepository(TContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        
        #endregion
        #region Instance Methods
        public T GetSingle(int id)
        {
            return _dbSet.Find(id);
        }

        public T GetSingle(long id)
        {
            return _dbSet.Find(id);
        }

        public async Task<T> GetSingleAsync(int id)
        {
            var res = _dbSet.FindAsync(id);
            return await res;
        }

        public async Task<T> GetSingleAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        }

        public List<T> GetList()
        {
            return _dbSet.ToList<T>();
        }
        public async Task<List<T>> GetListAsync()
        {
            return await _dbSet.ToListAsync<T>();
        }

        

        public IEnumerable<T> Get()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _dbSet.Where(predicate);
            return query;
        }


        #endregion

        //#region Destructors
        //public void Dispose()
        //{
        //     _db.Dispose();
        //}
        //#endregion
    }
}