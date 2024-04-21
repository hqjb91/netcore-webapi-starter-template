using Ardalis.Specification;

namespace Application.Contracts.Persistence.Repositories;
public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}