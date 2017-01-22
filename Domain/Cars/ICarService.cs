using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Cars;

namespace Domain.Cars
{
    public interface ICarService : IDomainService<Car>
    {
        int GetCount();
        IQueryable<Car> GetByName(string name);
        void Insert(Car car);
        void Delete(string readerLine);
    }
}
