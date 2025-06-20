using AutoMapper;
using Project2144.Interns;
using Project2144.Interns.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.AutoMapper
{
    public class InternProfile:Profile
    {
        public InternProfile()
        {
            CreateMap<Intern,  UpdateInternDto>().ReverseMap();
            CreateMap<Intern, CreateInternDto>().ReverseMap();
        }
    }
}
