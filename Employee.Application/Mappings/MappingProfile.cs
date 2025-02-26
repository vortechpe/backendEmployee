
using AutoMapper;
using Employee.Application.DTOs;
using Employee.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Mappings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Employees, EmployeeDto>()
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.Afp, opt => opt.MapFrom(src => src.Afp.Name))
                .ForMember(dest => dest.PositionId, opt => opt.MapFrom(src => src.Position.PositionId))
                .ForMember(dest => dest.AfpId, opt => opt.MapFrom(src => src.Afp.AfpId));

        }
    }
}
