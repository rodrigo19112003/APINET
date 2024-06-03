using backendnet.Data.Seed;
using backendnet.Models;
using Microsoft.EntityFrameworkCore;

namespace backendnet.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Movie> Movie { get; set; }
    public DbSet<Category> Category { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SeedCategory());
        modelBuilder.ApplyConfiguration(new SeedMovie());
    }
}