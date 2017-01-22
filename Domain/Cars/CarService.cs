using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cars
{
    public class CarService : ICarService
    {
        private readonly ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IQueryable<Car> GetByName(string name)
        {
            return this.carRepository.Get
                (
                    c =>
                    c.CarType.Name.ToLower()
                    .Contains(name.ToLower())
                );
        }

        public int GetCount()
        {
            return carRepository.GetAll().Count();
        }

        public void Insert(Car car)
        {
            this.carRepository.Insert(car);
        }

        public void Delete(string id)
        {
            Car car = this.carRepository.Find(id);
            if (car != null)
                this.carRepository.Delete(car);
        }

        public IQueryable<Car> GetAll()
        {
            return this.carRepository.GetAll();
        }
    }
}
