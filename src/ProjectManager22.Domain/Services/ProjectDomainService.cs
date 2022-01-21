using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Entities;
using ProjectManager22.Domain.Interfaces.Repositories;
using ProjectManager22.Domain.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Services
{
    public class ProjectDomainService : IProjectDomainService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectDomainService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task CreateAsync(ProjectDto dto)
        {
            var project = new Project(dto.Name, dto.StartDate, dto.Manager, dto.EstimatedProjectEndDate, dto.RealProjectEndDate, dto.BudgetTotal, dto.Description, dto.Status);

            await _projectRepository.InsertAndSaveChangesAsync(project);
        }

        public async Task<string> UpdateAsync(ProjectDto dto)
        {
            var project = await _projectRepository.GetByIdAsync(dto.Id);
            if (project == null)
                return "Projeto não existe";

            project.Update(dto.Name, dto.StartDate, dto.Manager, dto.EstimatedProjectEndDate, dto.RealProjectEndDate, dto.BudgetTotal, dto.Description, dto.Status);

            await _projectRepository.UpdateAndSaveChangesAsync(project);

            return null;
        }

        public async Task<string> RemoveAsync(Guid id)
        {
            var project = await _projectRepository.GetByIdAsync(id);
            if (project == null)
                return "Projeto não existe";

            if (!project.CanRemove())
                return "Não é possível excluir esse projeto";

            await _projectRepository.RemoveAndSaveChangesAsync(project);

            return null;
        }
    }
}
