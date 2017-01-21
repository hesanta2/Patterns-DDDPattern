using Domain.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Services
{
    public class CarService : ICarService
    {
        private ICarRepository carRepository;

        public CarService(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public IQueryable<Car> GetByName(string name)
        {
            return this.carRepository.Get(car => car.CarType.Name == name);
        }
    }
}
