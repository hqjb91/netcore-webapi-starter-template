using Application.Contracts.Persistence.Repositories;
using Ardalis.Specification.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ApplicationRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T>  where T : class
{
    private readonly ApplicationDbContext _dbContext;

    public ApplicationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}