using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CourseEnroll.Application.Feature.Students.Interfaces;
using CourseEnroll.Application.Feature.Students.Mappers;
using CourseEnroll.Application.Feature.Students.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CourseEnroll.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(StudentMappingProfile).Assembly);

            services.AddScoped<IStudentService, StudentService>();
            return services;
        }
    }
}