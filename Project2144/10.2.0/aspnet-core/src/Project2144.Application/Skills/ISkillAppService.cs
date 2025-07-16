using Project2144.Skills.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Skills
{
    public interface ISkillAppService
    {
        Task<List<UpdateSkillDto>> GetAllAsync();
        Task<UpdateSkillDto> GetAsync(int id);
        Task CreateAsync(CreateSkillDto input);
        Task UpdateAsync(UpdateSkillDto input);
        Task DeleteAsync(int id);
    }
}
