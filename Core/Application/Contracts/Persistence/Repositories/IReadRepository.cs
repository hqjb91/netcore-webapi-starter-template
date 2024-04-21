using Ardalis.Specification;

namespace Application.Contracts.Persistence.Repositories;
public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class
{
}