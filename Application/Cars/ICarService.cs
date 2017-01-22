using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Cars;

namespace Application.Cars
{
    public interface ICarService : IApplicationService<Car>
    {
        IQueryable<Car> GetByName(string name);
    }
}
