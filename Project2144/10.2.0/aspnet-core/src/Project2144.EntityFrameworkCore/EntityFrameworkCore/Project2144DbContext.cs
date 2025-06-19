using Abp.Zero.EntityFrameworkCore;
using Project2144.Authorization.Roles;
using Project2144.Authorization.Users;
using Project2144.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using Project2144.Projects;

namespace Project2144.EntityFrameworkCore;

public class Project2144DbContext : AbpZeroDbContext<Tenant, Role, User, Project2144DbContext>
{
    /* Define a DbSet for each entity of the application */

    public DbSet<Product> Products { get; set; }
    public Project2144DbContext(DbContextOptions<Project2144DbContext> options)
        : base(options)
    {
    }
}
