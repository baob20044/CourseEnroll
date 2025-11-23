using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseEnroll.Application.Feature.Students.DTOs;
using CourseEnroll.Domain.Entities;

namespace CourseEnroll.Application.Feature.Students.Mappers
{
    public class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentCreateDto, Student>();

            CreateMap<Student, StudentSummaryDto>()
                .ForMember(des => des.DisplayName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)
            );

            CreateMap<Student, StudentDetailDto>();
        }
    }
}