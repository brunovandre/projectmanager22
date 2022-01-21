using ProjectManager22.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager22.Domain.Dtos
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Data de Início")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Gerente Responsável")]
        public string Manager { get; set; }

        [Required]
        [Display(Name = "Previsão de término")]
        public DateTime EstimatedProjectEndDate { get; set; }

        [Display(Name = "Data de conclusão")]
        public DateTime? RealProjectEndDate { get; set; }

        [Display(Name = "Total do Orçamento")]
        public decimal? BudgetTotal { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Status")]
        public ProjectStatusEnum Status { get; set; }
    }
}
