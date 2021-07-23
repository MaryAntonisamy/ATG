using ATG.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATG.Repositories.Contracts
{
    public interface IGenericRepository<TContext, T> 
        where TContext : DbContext
        where T : class
    {
        T GetSingle(int id);
        T GetSingle(long id);
        Task<T> GetSingleAsync(int id);
        Task<T> GetSingleAsync(long id);
        List<T> GetList();
        Task<List<T>> GetListAsync();
        IEnumerable<T> Get();
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}
