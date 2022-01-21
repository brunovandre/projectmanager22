using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Interfaces.Repositories
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<Project> GetByIdAsync(Guid id);
        Task<ProjectDto> GetDtoByIdAsync(Guid id);
        Task<List<ProjectDto>> GetAllAsync();
    }
}
