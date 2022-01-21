using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager22.Domain.Entities;
using ProjectManager22.Infra.Mappings;

namespace ProjectManager22.Infra
{
    public class ProjectManager22DbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbSet<Project> Projects { get; set; }
        public DbSet<Member> Members { get; set; }

        public ProjectManager22DbContext(
           DbContextOptions<ProjectManager22DbContext> options,
           IConfiguration configuration)
           : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectMapping());
            modelBuilder.ApplyConfiguration(new MemberMapping());
        }
    }
}
