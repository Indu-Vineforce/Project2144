using Abp.Domain.Repositories;
using Project2144.Interns.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.UI;

namespace Project2144.Interns
{
    public class InternAppService : Project2144AppServiceBase, IInternAppService
    {
        private readonly IRepository<Intern, int> _repository;

        public InternAppService(IRepository<Intern, int> repository)
        {
            _repository = repository;
        }

        // CREATE
        public async Task<UpdateInternDto> CreateAsync(CreateInternDto input)
        {
            var intern = ObjectMapper.Map<Intern>(input);
            intern = await _repository.InsertAsync(intern);
            return ObjectMapper.Map<UpdateInternDto>(intern);
        }

        // READ ALL
        public async Task<List<UpdateInternDto>> GetAllAsync()
        {
            var interns = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<UpdateInternDto>>(interns);
        }

        // READ ONE
        public async Task<UpdateInternDto> GetByIdAsync(int id)
        {
            var intern = await _repository.FirstOrDefaultAsync(id);
            if (intern == null)
                throw new UserFriendlyException("Intern not found");

            return ObjectMapper.Map<UpdateInternDto>(intern);
        }

        // UPDATE
        public async Task<UpdateInternDto> UpdateAsync(UpdateInternDto input)
        {
            var intern = await _repository.FirstOrDefaultAsync(input.Id);
            if (intern == null)
                throw new UserFriendlyException("Intern not found");

            ObjectMapper.Map(input, intern);
            await _repository.UpdateAsync(intern);
            return ObjectMapper.Map<UpdateInternDto>(intern);
        }

        // DELETE
        public async Task DeleteAsync(int id)
        {
            var intern = await _repository.FirstOrDefaultAsync(id);
            if (intern == null)
                throw new UserFriendlyException("Intern not found");

            await _repository.DeleteAsync(id);
        }
    }
}
