using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Project2144.Configuration;
using Project2144.EntityFrameworkCore;
using Project2144.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace Project2144.Migrator;

[DependsOn(typeof(Project2144EntityFrameworkModule))]
public class Project2144MigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public Project2144MigratorModule(Project2144EntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(Project2144MigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            Project2144Consts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(Project2144MigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
