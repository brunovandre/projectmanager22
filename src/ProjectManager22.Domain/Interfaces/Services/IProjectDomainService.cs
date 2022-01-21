using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Interfaces.Services
{
    public interface IProjectDomainService
    {
        Task CreateAsync(ProjectDto dto);
        Task<string> UpdateAsync(ProjectDto dto);
        Task<string> RemoveAsync(Guid id);
    }
}
