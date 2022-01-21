using Microsoft.Extensions.DependencyInjection;
using ProjectManager22.Domain.Interfaces.Services;
using ProjectManager22.Domain.Services;

namespace ProjectManager22.Domain
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddDomainDependency(this IServiceCollection services)
        {
            services.AddScoped<IProjectDomainService, ProjectDomainService>();
            services.AddScoped<IMemberDomainService, MemberDomainService>();

            return services;
        }
    }
}
