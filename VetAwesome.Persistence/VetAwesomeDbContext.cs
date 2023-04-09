using Microsoft.EntityFrameworkCore;

namespace VetAwesome.Persistence;

public class VetAwesomeDbContext : DbContext
{
    public VetAwesomeDbContext()
        : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var thisAssembly = typeof(VetAwesomeDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(thisAssembly);
    }
}
