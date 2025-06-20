using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using Project2144.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Project2144.Departments
{
    public class DepartmentAppService : Project2144AppServiceBase
    {
        private readonly IRepository<Department,int> _repository;
        public DepartmentAppService(IRepository<Department,int> repository)
        {
            _repository = repository;
        }
        public async Task<List<UpdateDepartmentDto>> GetAll()
        {
            var departments = await _repository.GetAllListAsync();
            return ObjectMapper.Map<List<UpdateDepartmentDto>>(departments);
        }
        public async Task<UpdateDepartmentDto> GetAsync(EntityDto<int> input)
        {
            try
            {
                var dept = await _repository.FirstOrDefaultAsync(input.Id);
                if (dept == null)
                {
                    throw new UserFriendlyException("Department not found");
                }
                return ObjectMapper.Map<UpdateDepartmentDto>(dept);
            }
            catch (Exception ex)
            {
                Logger.Error("Error in GetAsync:", ex);
                throw new UserFriendlyException("An error occurred while fetching the department.");
            }
        }
        public async Task<UpdateDepartmentDto> CreateAsync(CreateDepartmentDto input)
        {
            var entity = ObjectMapper.Map<Department>(input);
            await _repository.InsertAsync(entity);
            return ObjectMapper.Map<UpdateDepartmentDto>(entity);
        }
        public async Task<UpdateDepartmentDto> UpdateAsync(UpdateDepartmentDto input)
        {
            var dept = await _repository.FirstOrDefaultAsync(input.Id);
            if (dept == null)
            {
                throw new UserFriendlyException("Department not found");
            }

            ObjectMapper.Map(input, dept);
            await _repository.UpdateAsync(dept);

            return ObjectMapper.Map<UpdateDepartmentDto>(dept);
        }
        public async Task DeleteAsync(EntityDto<int> input)
        {
            await _repository.DeleteAsync(input.Id);
        }
    }
}
