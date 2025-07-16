using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using Project2144.Cities;
using Project2144.Citites.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Citites
{
    public class CityAppService : ApplicationService, ICityAppService
    {
        private readonly IRepository<City, Guid> _cityRepository;

        public CityAppService(IRepository<City, Guid> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ListResultDto<CityListDto>> GetAllAsync()
        {
            var cities = await _cityRepository
                .GetAllIncluding(x => x.Country, x => x.State)
                .ToListAsync();

            var result = ObjectMapper.Map<List<CityListDto>>(cities);
            return new ListResultDto<CityListDto>(result);
        }

        public async Task<CityDto> GetAsync(EntityDto<Guid> input)
        {
            var city = await _cityRepository.GetAsync(input.Id);
            return ObjectMapper.Map<CityDto>(city);
        }

        public async Task<CityDto> CreateAsync(CreateCityDto input)
        {
            var entity = ObjectMapper.Map<City>(input);
            entity.Id = Guid.NewGuid();

            await _cityRepository.InsertAsync(entity);
            return ObjectMapper.Map<CityDto>(entity);
        }

        public async Task<CityDto> UpdateAsync(CityDto input)
        {
            var city = await _cityRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, city);
            return ObjectMapper.Map<CityDto>(city);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _cityRepository.DeleteAsync(input.Id);
        }
    }
}
