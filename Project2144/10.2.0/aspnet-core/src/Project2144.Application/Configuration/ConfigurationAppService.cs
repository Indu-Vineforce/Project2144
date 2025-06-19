using Abp.Authorization;
using Abp.Runtime.Session;
using Project2144.Configuration.Dto;
using System.Threading.Tasks;

namespace Project2144.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : Project2144AppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
