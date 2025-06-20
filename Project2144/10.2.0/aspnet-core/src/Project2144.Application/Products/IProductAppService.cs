using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Project2144.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Products
{
    public interface IProductAppService : IAsyncCrudAppService<
       ProductDto,              // TEntityDto
       int,                     // TPrimaryKey
       PagedAndSortedResultRequestDto,  // TGetAllInput
       CreateProductDto,              // TCreateInput (temporary)
       ProductDto>              // TUpdateInput (temporary)
    {
    }
}
