using AutoMapper;
using Project2144.Cities;
using Project2144.Citites.Dto;
using Project2144.Countries.Dto;
using Project2144.CSC;
using Project2144.States.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2144.AutoMapper
{
    public class CountryProfile:Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, CountryListDto>()
                .ForMember(dest => dest.StateCount, opt => opt.MapFrom(src => src.States.Count));
            CreateMap<CreateCountryDto, Country>();
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<CreateStateDto, State>();
            CreateMap<State, StateListDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<CreateCityDto, City>();
            CreateMap<City, CityListDto>()
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name))
                .ForMember(dest => dest.StateName, opt => opt.MapFrom(src => src.State.Name));
        }
    }
}
