using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T Find(object id);
    }
}
