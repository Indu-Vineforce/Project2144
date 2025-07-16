using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project2144.States.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.States
{
    public interface IStateAppService 
    {
        Task<ListResultDto<StateListDto>> GetAllAsync();

        Task<StateDto> GetAsync(EntityDto<Guid> input);

        Task<StateDto> CreateAsync(CreateStateDto input);

        Task<StateDto> UpdateAsync(StateDto input);

        Task DeleteAsync(EntityDto<Guid> input);
    }
}
