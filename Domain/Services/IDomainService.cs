using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Cars;

namespace Domain.Services
{
    public interface IDomainService<T> where T : IAggregateRoot
    {
    }
}
