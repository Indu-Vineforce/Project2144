using AutoMapper;
using Project2144.AutoMapper;
using Project2144.Departments;
using Project2144.Departments.Dto;
using Project2144.Products.Dto;
using Project2144.Projects;
using Project2144.Skills;
using Project2144.Skills.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.AutoMapper
{
    public class SkillProfile:Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, CreateSkillDto>().ReverseMap();

            CreateMap<Skill, UpdateSkillDto>().ReverseMap();
        }
    }
}
