using Abp.Application.Services;
using Project2144.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace Project2144.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
