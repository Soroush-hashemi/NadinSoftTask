using Common.Domain.Bases;
using Domain.Product;
using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class Context : DbContext
{
    private Context()
    {

    }

    public Context(DbContextOptions<Context> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }

    private List<BaseEntity> GetModifiedEntities() =>
    ChangeTracker.Entries<BaseEntity>()
        .Where(x => x.State != EntityState.Detached)
        .Select(c => c.Entity)
        .Where(c => c.DomainEvents.Any()).ToList();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}