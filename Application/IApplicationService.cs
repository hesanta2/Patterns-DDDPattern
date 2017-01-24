using Domain;

namespace Application
{
    public interface IApplicationService<T> where T : IAggregateRoot
    {
    }
}