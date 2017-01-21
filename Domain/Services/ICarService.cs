using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Cars;

namespace Domain.Services
{
    public interface ICarService : IDomainService<Car>
    {
        IQueryable<Car> GetByName(string name);
    }
}
