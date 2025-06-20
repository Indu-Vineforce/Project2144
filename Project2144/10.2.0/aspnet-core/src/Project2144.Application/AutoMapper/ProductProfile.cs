using AutoMapper;
using Project2144.Products.Dto;
using Project2144.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.AutoMapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
          
            CreateMap<Product, ProductDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
        }
    }
}
