using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Project2144.Controllers
{
    public abstract class Project2144ControllerBase : AbpController
    {
        protected Project2144ControllerBase()
        {
            LocalizationSourceName = Project2144Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
