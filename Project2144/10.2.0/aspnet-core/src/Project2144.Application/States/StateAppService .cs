using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Microsoft.EntityFrameworkCore;
using Project2144.CSC;
using Project2144.States.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.States
{
    public class StateAppService : Project2144AppServiceBase
    {
        private readonly IRepository<State, Guid> _stateRepository;

        public StateAppService(IRepository<State, Guid> stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ListResultDto<StateListDto>> GetAllAsync()
        {
            var states = await _stateRepository
                .GetAllIncluding(x => x.Country) // Assuming navigation property Country
                .ToListAsync();

            var result = ObjectMapper.Map<List<StateListDto>>(states);
            return new ListResultDto<StateListDto>(result);
        }

        public async Task<StateDto> GetAsync(EntityDto<Guid> input)
        {
            var state = await _stateRepository.GetAsync(input.Id);
            return ObjectMapper.Map<StateDto>(state);
        }

        public async Task<StateDto> CreateAsync(CreateStateDto input)
        {
            var entity = ObjectMapper.Map<State>(input);
            entity.Id = Guid.NewGuid();

            await _stateRepository.InsertAsync(entity);
            return ObjectMapper.Map<StateDto>(entity);
        }

        public async Task<StateDto> UpdateAsync(StateDto input)
        {
            var state = await _stateRepository.GetAsync(input.Id);
            ObjectMapper.Map(input, state);
            return ObjectMapper.Map<StateDto>(state);
        }

        public async Task DeleteAsync(EntityDto<Guid> input)
        {
            await _stateRepository.DeleteAsync(input.Id);
        }
    }
}
