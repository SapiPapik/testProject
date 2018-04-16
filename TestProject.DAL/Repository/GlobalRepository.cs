using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using TestProject.DAL.Contracts;

namespace TestProject.DAL.Repository
{
    public class GlobalRepository<T> : IGlobalRepository<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public GlobalRepository(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return DbSet;
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = All();
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual T GetByIdIncluding(
            Expression<Func<T, bool>> predicate, 
            params Expression<Func<T, object>>[] includeProperties
        ) {
            var result = All();
            if (includeProperties.Any())
            {
                foreach (var include in includeProperties)
                {
                    result = result.Include(include);
                }
            }
            return result.FirstOrDefault(predicate);
        }

        public virtual IQueryable<T> Where(params Expression<Func<T, bool>>[] predicates)
        {
            IQueryable<T> query = All();
            foreach (var predicate in predicates)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        public T GetById(object id)
        {
            return DbSet.Find(id);
        }

        public void Create(T item)
        {
            DbSet.Add(item);
        }

        public void Update(T item)
        {
            Context.Entry(item).State = EntityState.Modified;
        }

        public virtual void Remove(T entity)
        {
            DbEntityEntry dbEntityEntry = Context.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Remove(object id)
        {
            var entity = GetById(id);
            if (entity == null) return;
            Remove(entity);
        }
    }
}