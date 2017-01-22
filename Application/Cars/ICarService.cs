using System.Linq;
using Domain.Cars;

namespace Application.Cars
{
    public interface ICarService : IApplicationService<Car>
    {
        IQueryable<Car> GetAll();
        IQueryable<Car> GetByName(string name);
        void Insert(Car car);
        void Delete(string readerLine);
    }
}
