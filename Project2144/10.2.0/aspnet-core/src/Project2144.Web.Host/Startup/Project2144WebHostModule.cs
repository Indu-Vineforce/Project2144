using Abp.Modules;
using Abp.Reflection.Extensions;
using Project2144.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Project2144.Web.Host.Startup
{
    [DependsOn(
       typeof(Project2144WebCoreModule))]
    public class Project2144WebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public Project2144WebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(Project2144WebHostModule).GetAssembly());
        }
    }
}
