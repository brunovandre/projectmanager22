using ProjectManager22.Domain.Enums;
using System;
using System.Collections.Generic;

namespace ProjectManager22.Domain.Entities
{
    public class Project : Entity
    {
        protected Project() { }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public string Manager { get; private set; }
        public DateTime EstimatedProjectEndDate { get; private set; }
        public DateTime? RealProjectEndDate { get; private set; }
        public decimal? BudgetTotal { get; private set; }
        public string Description { get; private set; }
        public ProjectStatusEnum Status { get; private set; }


        public Project(string name, DateTime startDate, string manager, DateTime estimatedProjectEndDate, DateTime? realProjectEndDate, decimal? budgetTotal, string description, ProjectStatusEnum status)
        {
            Id = Guid.NewGuid();
            Name = name;
            StartDate = startDate;
            Manager = manager;
            EstimatedProjectEndDate = estimatedProjectEndDate;
            RealProjectEndDate = realProjectEndDate;
            BudgetTotal = budgetTotal;
            Description = description;
            Status = status;
        }

        public void Update(string name, DateTime startDate, string manager, DateTime estimatedProjectEndDate, DateTime? realProjectEndDate, decimal? budgetTotal, string description, ProjectStatusEnum statusEnum)
        {
            Name = name;
            StartDate = startDate;
            Manager = manager;
            EstimatedProjectEndDate = estimatedProjectEndDate;
            RealProjectEndDate = realProjectEndDate;
            BudgetTotal = budgetTotal;
            Description = description;
            Status = statusEnum;
        }

        public bool CanRemove()
        {
            var statusCanNotRemove = new List<ProjectStatusEnum> { ProjectStatusEnum.Started, ProjectStatusEnum.InProgress, ProjectStatusEnum.Closed };

            if (statusCanNotRemove.Contains(Status))
                return false;

            return true;
        }
    }
}
