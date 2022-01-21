using Microsoft.EntityFrameworkCore;
using ProjectManager22.Domain.Dtos;
using ProjectManager22.Domain.Entities;
using ProjectManager22.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Infra.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ProjectManager22DbContext context) : base(context)
        {

        }

        public async Task<ProjectDto> GetDtoByIdAsync(Guid id)
            => (await Context.Projects.Select(x => new ProjectDto 
            {
              Id = x.Id,
                BudgetTotal = x.BudgetTotal,
              Description = x.Description,
              EstimatedProjectEndDate = x.EstimatedProjectEndDate,
              Manager = x.Manager,
              Name = x.Name,
              RealProjectEndDate = x.RealProjectEndDate,
              StartDate = x.StartDate,
              Status = x.Status
            }).FirstOrDefaultAsync(x => x.Id == id));

        public async Task<Project> GetByIdAsync(Guid id)
            => (await Context.Projects.FirstOrDefaultAsync(x => x.Id == id));

        public async Task<List<ProjectDto>> GetAllAsync()
            => await Context.Projects.Select(x => new ProjectDto
            {
                Id = x.Id,
                BudgetTotal = x.BudgetTotal,
              Description = x.Description,
              EstimatedProjectEndDate = x.EstimatedProjectEndDate,
              Manager = x.Manager,
              Name = x.Name,
              RealProjectEndDate = x.RealProjectEndDate,
              StartDate = x.StartDate,
              Status = x.Status
            }).ToListAsync();
    }
}
