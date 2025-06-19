using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Project2144.MultiTenancy;

namespace Project2144.Sessions.Dto;

[AutoMapFrom(typeof(Tenant))]
public class TenantLoginInfoDto : EntityDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
