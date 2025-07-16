using Abp.Zero.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project2144.Authorization.Roles;
using Project2144.Authorization.Users;
using Project2144.Cities;
using Project2144.CSC;
using Project2144.Departments;
using Project2144.Interns;
using Project2144.MultiTenancy;
using Project2144.Projects;
using Project2144.Skills;

namespace Project2144.EntityFrameworkCore;

public class Project2144DbContext : AbpZeroDbContext<Tenant, Role, User, Project2144DbContext>
{
    /* Define a DbSet for each entity of the application */

    public DbSet<Product> Products { get; set; }
    public DbSet<Department> Department { get; set; }
    public DbSet<Intern> Interns { get; set; }
    public DbSet<Skill> Skills {  get; set; }

    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Cities { get; set; }

    public Project2144DbContext(DbContextOptions<Project2144DbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Country configuration
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasIndex(c => c.Name).IsUnique();
            entity.Property(c => c.IsActive).HasDefaultValue(true);
        });

        // State configuration
        modelBuilder.Entity<State>(entity =>
        {
            entity.HasIndex(s => new { s.Name, s.CountryId }).IsUnique();
            entity.HasOne(s => s.Country)
                  .WithMany(c => c.States)
                  .HasForeignKey(s => s.CountryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // City configuration
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasIndex(c => new { c.Name, c.StateId }).IsUnique();
            entity.HasOne(c => c.State)
                  .WithMany(s => s.Cities)
                  .HasForeignKey(c => c.StateId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(c => c.Country)
                  .WithMany()
                  .HasForeignKey(c => c.CountryId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
