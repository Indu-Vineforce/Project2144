using Abp.Application.Services.Dto;
using Project2144.Citites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Citites
{
    public interface ICityAppService
    {
        Task<ListResultDto<CityListDto>> GetAllAsync();
        Task<CityDto> GetAsync(EntityDto<Guid> input);
        Task<CityDto> CreateAsync(CreateCityDto input);
        Task<CityDto> UpdateAsync(CityDto input);
        Task DeleteAsync(EntityDto<Guid> input);
    }
}
