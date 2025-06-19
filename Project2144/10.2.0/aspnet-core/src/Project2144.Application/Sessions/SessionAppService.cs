using Abp.Auditing;
using Project2144.Sessions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2144.Sessions;

public class SessionAppService : Project2144AppServiceBase, ISessionAppService
{
    [DisableAuditing]
    public async Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations()
    {
        var output = new GetCurrentLoginInformationsOutput
        {
            Application = new ApplicationInfoDto
            {
                Version = AppVersionHelper.Version,
                ReleaseDate = AppVersionHelper.ReleaseDate,
                Features = new Dictionary<string, bool>()
            }
        };

        if (AbpSession.TenantId.HasValue)
        {
            output.Tenant = ObjectMapper.Map<TenantLoginInfoDto>(await GetCurrentTenantAsync());
        }

        if (AbpSession.UserId.HasValue)
        {
            output.User = ObjectMapper.Map<UserLoginInfoDto>(await GetCurrentUserAsync());
        }

        return output;
    }
}
