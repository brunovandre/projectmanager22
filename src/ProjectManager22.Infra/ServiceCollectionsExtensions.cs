using Microsoft.Extensions.DependencyInjection;
using ProjectManager22.Domain.Interfaces.Repositories;
using ProjectManager22.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Infra
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddInfraDependency(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<ProjectManager22DbContext>();

            return services;
        }
    }
}
