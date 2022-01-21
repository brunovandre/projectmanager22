using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectManager22.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Infra.Mappings
{
    public class ProjectMapping : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("project");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Manager).IsRequired();
            builder.Property(p => p.StartDate).IsRequired();
            builder.Property(p => p.Status).IsRequired();
            builder.Property(p => p.EstimatedProjectEndDate).IsRequired();
            builder.Property(p => p.BudgetTotal).HasColumnType("decimal(18, 2)");
        }
    }
}
