using GraphQL.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GraphQL.Core.Repositories
{
    public interface IRepository<T> : IBaseRepository where T : class, IEntity
    {
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        T Delete(T entity);
        List<T> Delete(List<T> entities);
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, int skip = 0, int take = 0, params Expression<Func<T, object>>[] includes);
        Task<T> GetAsync(Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes);
        IQueryable<T> Query();
        Task<long> GetCountAsync(Expression<Func<T, bool>> expression = null);
    }
}
