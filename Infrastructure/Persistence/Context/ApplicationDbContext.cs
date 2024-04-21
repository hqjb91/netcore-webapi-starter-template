using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<EAVEntity> EAVEntities { get; set; }
    public DbSet<EAVAttribute> EAVAttributes { get; set; }
    public DbSet<EAVValue> EAVValues { get; set; }
}