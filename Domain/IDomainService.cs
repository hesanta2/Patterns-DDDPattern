using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Domain
{
    public interface IDomainService<T> where T : IAggregateRoot
    {
    }
}
