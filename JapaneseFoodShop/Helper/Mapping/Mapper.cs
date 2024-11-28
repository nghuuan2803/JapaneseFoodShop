using AutoMapper;
using JapaneseFoodShop.DTOs;
using JapaneseFoodShop.Entities;

namespace JapaneseFoodShop.Helper.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            //CreateMap<EmployeeDTO, Employee>();
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ReverseMap();
        }
    }
}
