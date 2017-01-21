using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Cars;

namespace Infraesctructure.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        public void Insert(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Car> Get(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public Car Find(string id)
        {
            throw new NotImplementedException();
        }
    }
}
