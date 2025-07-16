using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using Project2144.Countries.Dto;
using Project2144.CSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Countries
{
    public class CountryAppService :Project2144AppServiceBase
    {
        private readonly IRepository<Country, Guid> _countryRepository;

        public CountryAppService(IRepository<Country, Guid> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<ListResultDto<CountryListDto>> GetAllAsync()
        {
            var countries = await _countryRepository
                .GetAll()
                .Include(c => c.States)
                .ToListAsync();
            var result = ObjectMapper.Map<List<CountryListDto>>(countries);
            return new ListResultDto<CountryListDto>(result);
        }

        public async Task<CountryDto> GetAsync(EntityDto<Guid> input)
        {
            var country = await _countryRepository.GetAsync(input.Id);
            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> CreateAsync(CreateCountryDto input)
        {
            var country = ObjectMapper.Map<Country>(input);
            country.Id = Guid.NewGuid();

            await _countryRepository.InsertAsync(country);

            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task<CountryDto> UpdateAsync(CountryDto input)
        {
            var country = await _countryRepository.GetAsync(input.Id);

            // Map changes from DTO to entity
            ObjectMapper.Map(input, country);

            // EF Core will track and save changes automatically
            return ObjectMapper.Map<CountryDto>(country);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _countryRepository.DeleteAsync(input.Id);
        }
    }
}
