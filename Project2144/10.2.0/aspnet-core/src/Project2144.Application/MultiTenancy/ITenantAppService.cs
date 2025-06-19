using Abp.Application.Services;
using Project2144.MultiTenancy.Dto;

namespace Project2144.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

