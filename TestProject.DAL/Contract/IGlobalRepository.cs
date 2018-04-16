using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TestProject.DAL.Contracts
{
    public interface IGlobalRepository<T> where T : class
    {
        IQueryable<T> All();
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T GetByIdIncluding(Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties
        );
        IQueryable<T> Where(params Expression<Func<T, bool>>[] predicates);

        T GetById(object id);
        void Create(T item);
        void Update(T item);
        void Remove(T entity);
        void Remove(object id);
    }
}
