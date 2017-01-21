using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using  CsQuery;
using Domain;
using Domain.Cars;

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

        public IQueryable<Car> Get(string key)
        {
            List<Car> results = new List<Car>();

            CQ cq = CQ.CreateFromUrl($"http://www.autoevolution.com/search.php?t=cars&s={key}");
            cq = cq.Find(".srcar a");

            foreach (var element in cq.Elements)
            {
                string name = element.InnerText;
                Car car = new Car("", CarClass.Normal, name, Color.Transparent, 0, 0);

                results.Add(car);
            }

            return results.AsQueryable();
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
