using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> Get(string key);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T Find(string id);
    }
}
