using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Project2144.EntityFrameworkCore;
using Project2144.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Project2144.Web.Tests;

[DependsOn(
    typeof(Project2144WebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class Project2144WebTestModule : AbpModule
{
    public Project2144WebTestModule(Project2144EntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Project2144WebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(Project2144WebMvcModule).Assembly);
    }
}