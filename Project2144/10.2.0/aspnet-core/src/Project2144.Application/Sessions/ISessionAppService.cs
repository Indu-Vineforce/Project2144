using Abp.Application.Services;
using Project2144.Sessions.Dto;
using System.Threading.Tasks;

namespace Project2144.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
