using AutoMapper;
using CLIMFinders.Application.DTOs;
using CLIMFinders.Domain.Entities;
using Given.DataContext.Entities;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace CLIMFinders.Web.ServiceExtension
{
    public class GenericMappingProfile : Profile
    {
        public GenericMappingProfile()
        {
            CreateMap<User, LoginResponseDto>()
                 .ForMember(dest => dest.BusinessId, opt => opt.MapFrom(src => src.Businesses != null ? src.Businesses.Id : (int?)null))
                .ReverseMap();
            CreateMap<Businesses, RegisterDto>().ReverseMap();
            CreateMap<Vehicles, VehicleDto>().ReverseMap();

            CreateMap<Vehicles, VehicleListDto>()
            .ForMember(dest => dest.Make, opt => opt.MapFrom(src => src.VehicleMake.Name))
            .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.VehicleModel.Name))
            .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.VehicleColor.Name))
            .ReverseMap();
        }
    }
}
