using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project2144.Countries.Dto;
using System;
using System.Threading.Tasks;

namespace Project2144.Countries
{
    public interface ICountryAppService 
    {
        Task<ListResultDto<CountryListDto>> GetAllAsync();

        Task<CountryDto> GetAsync(EntityDto<Guid> input);

        Task<CountryDto> CreateAsync(CreateCountryDto input);

        Task<CountryDto> UpdateAsync(CountryDto input);

        Task DeleteAsync(EntityDto<Guid> input);
    }
}
