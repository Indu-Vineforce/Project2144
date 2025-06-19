using Project2144.Configuration;
using Project2144.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Project2144.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class Project2144DbContextFactory : IDesignTimeDbContextFactory<Project2144DbContext>
{
    public Project2144DbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<Project2144DbContext>();

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        Project2144DbContextConfigurer.Configure(builder, configuration.GetConnectionString(Project2144Consts.ConnectionStringName));

        return new Project2144DbContext(builder.Options);
    }
}
