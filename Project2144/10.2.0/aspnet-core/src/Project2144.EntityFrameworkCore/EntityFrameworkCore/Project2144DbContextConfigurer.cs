using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Project2144.EntityFrameworkCore;

public static class Project2144DbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<Project2144DbContext> builder, string connectionString)
    {
        builder.UseSqlServer(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<Project2144DbContext> builder, DbConnection connection)
    {
        builder.UseSqlServer(connection);
    }
}
