using System.Linq;
using Domain.Cars;

namespace Application.Cars
{
    public class CarService : ICarService
    {
        private readonly Domain.Cars.ICarService carService;

        public CarService(Domain.Cars.ICarService carService)
        {
            this.carService = carService;
        }

        public IQueryable<Car> GetByName(string name)
        {
            var result = carService.GetByName(name);

            return result;
        }

        public void Insert(Car car)
        {
            if (car.Id == -1)
                car = new Car(
                    carService.GetAll().Count() + 1
                    , car.CarType.Class
                    , car.CarType.Name
                    , car.CarType.MaxSpeed
                    , car.CarType.Doors
                );

            carService.Insert(car);
        }

        public void Delete(int id)
        {
            carService.Delete(id);
        }

        public IQueryable<Car> GetAll()
        {
            return carService.GetAll();
        }
    }
}