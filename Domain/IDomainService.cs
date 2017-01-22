namespace Domain
{
    public interface IDomainService<T> where T : IAggregateRoot
    {
    }
}
