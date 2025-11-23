using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseEnroll.Domain.Interfaces;
using CourseEnroll.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CourseEnroll.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}