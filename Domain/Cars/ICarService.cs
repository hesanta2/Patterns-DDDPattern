using System.Linq;

namespace Domain.Cars
{
    public interface ICarService : IDomainService<Car>
    {
        int GetCount();
        IQueryable<Car> GetByName(string name);
        void Insert(Car car);
        void Delete(string id);
        IQueryable<Car> GetAll();
    }
}
