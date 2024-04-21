using Application.Contracts.Persistence.Repositories;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ApplicationConnectionString")));

        services.AddScoped(typeof(IRepository<>), typeof(ApplicationRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ApplicationRepository<>));
        return services;
    }
}