using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Project2144.Authorization;

namespace Project2144;

[DependsOn(
    typeof(Project2144CoreModule),
    typeof(AbpAutoMapperModule))]
public class Project2144ApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<Project2144AuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(Project2144ApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
