using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using Project2144.Skills.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Skills
{
    public class SkillAppService : ApplicationService, ISkillAppService
    {
        private readonly IRepository<Skill, int> _repository;

        public SkillAppService(IRepository<Skill, int> repository)
        {
            _repository = repository;
        }

        public async Task<List<UpdateSkillDto>> GetAllAsync()
        {
            var skills = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<UpdateSkillDto>>(skills);
        }

        public async Task<UpdateSkillDto> GetAsync(int id)
        {
            var skill = await _repository.GetAsync(id);
            return ObjectMapper.Map<UpdateSkillDto>(skill);
        }

        public async Task CreateAsync(CreateSkillDto input)
        {
            var skill = ObjectMapper.Map<Skill>(input);
            await _repository.InsertAsync(skill);
        }

        public async Task UpdateAsync(UpdateSkillDto input)
        {
            var skill = await _repository.GetAsync(input.Id);
            ObjectMapper.Map(input, skill);
            await _repository.UpdateAsync(skill);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
