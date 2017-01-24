using System.Linq;

namespace Domain.Cars
{
    public interface ICarService : IDomainService<Car>
    {
        IQueryable<Car> GetByName(string name);
        void Insert(Car car);
        void Delete(object id);
        IQueryable<Car> GetAll();
    }
}
