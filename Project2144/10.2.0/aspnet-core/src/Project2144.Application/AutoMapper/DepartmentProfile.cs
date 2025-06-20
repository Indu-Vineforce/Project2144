using AutoMapper;
using Project2144.Departments;
using Project2144.Departments.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.AutoMapper
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<Department, UpdateDepartmentDto>().ReverseMap();  
        }
    }
}
