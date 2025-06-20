using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project2144.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Departments
{
    public interface IDepartmentAppService
    {

        Task<List<UpdateDepartmentDto>> GetAllAsync();
        Task<UpdateDepartmentDto> GetAsync(EntityDto<int> input);
        Task<UpdateDepartmentDto> CreateAsync(CreateDepartmentDto input);
        Task<UpdateDepartmentDto> UpdateAsync(UpdateDepartmentDto input);
        Task DeleteAsync(EntityDto<int> id);
    }
}
