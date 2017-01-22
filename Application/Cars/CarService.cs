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
            IQueryable<Car> result = this.carService.GetByName(name);

            return result;
        }

        public void Insert(Car car)
        {
            if (string.IsNullOrWhiteSpace(car.Id))
                car = new Car(
                                (carService.GetAll().Count() + 1).ToString()
                                , car.CarType.Class
                                , car.CarType.Name
                                , car.CarType.MaxSpeed
                                , car.CarType.Doors
                            );

            this.carService.Insert(car);
        }

        public void Delete(string readerLine)
        {
            this.carService.Delete(readerLine);
        }

        public IQueryable<Car> GetAll()
        {
            return this.carService.GetAll();
        }
    }
}
