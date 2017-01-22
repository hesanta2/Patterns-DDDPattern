using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
