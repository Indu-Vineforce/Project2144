using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Project2144.Authorization;
using Project2144.Products.Dto;
using Project2144.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.Products
{
    
    public class ProductAppService : AsyncCrudAppService<
       Product,                  // Entity
       ProductDto,               // DTO
       int,                      // Primary key type
       PagedAndSortedResultRequestDto, // For filtering/sorting
       CreateProductDto,               // Create DTO (temporary)
       ProductDto>,              // Update DTO (temporary)
       IProductAppService
    {
        public ProductAppService(IRepository<Product, int> repository)
            : base(repository)
        {
        }
    }
}
