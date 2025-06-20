using Project2144.Interns.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project2144.Interns
{
    public interface IInternAppService
    {
        // CREATE
        Task<UpdateInternDto> CreateAsync(CreateInternDto input);

        // READ (ALL)
        Task<List<UpdateInternDto>> GetAllAsync();

        // READ (ONE)
        Task<UpdateInternDto> GetByIdAsync(int id);

        // UPDATE
        Task<UpdateInternDto> UpdateAsync(UpdateInternDto input);

        // DELETE
        Task DeleteAsync(int id);
    }
}
