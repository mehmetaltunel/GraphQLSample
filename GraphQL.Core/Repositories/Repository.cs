using GraphQL.Core.Entitiy;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GraphQL.Core.Repositories
{
    public class Repository<TEntity, TContext> : IRepository<TEntity>
              where TEntity : class, IEntity
              where TContext : DbContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(TContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            DbSet.Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            Context.AddRange(entities);
            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            Context.UpdateRange(entities);
            return entities;
        }

        public virtual TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return entity;
        }

        public virtual List<TEntity> Delete(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
            return entities;
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }
            return await query.AsNoTracking().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int skip = 0, int take = 0, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = Context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> include in includes)
            {
                query = query.Include(include);
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (take != 0)
            {
                query = query.Skip(skip).Take(take);
            }

            return await query.ToListAsync();
         }
    
        public virtual IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public virtual async Task<long> GetCountAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null
                ? await Context.Set<TEntity>().LongCountAsync()
                : await Context.Set<TEntity>().LongCountAsync(expression);
        }
    }

}
