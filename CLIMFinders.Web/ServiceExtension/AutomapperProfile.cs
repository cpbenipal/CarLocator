using AutoMapper;
using CLIMFinders.Application.DTOs;
using Given.DataContext.Entities;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace CLIMFinders.Web.ServiceExtension
{ 
    public class GenericMappingProfile : Profile
    {
        public GenericMappingProfile()
        {
            CreateMap<User, LoginResponseDto>().ReverseMap();
        }
    }
}
