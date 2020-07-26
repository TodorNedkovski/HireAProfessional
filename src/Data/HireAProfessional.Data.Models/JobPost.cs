namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using HireAProfessional.Data.Models.Enums;

    public class JobPost : BaseDeletableModel<string>
    {
        public JobPost()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Company { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        public double StartingSalary { get; set; }

        public double? HighestSalary { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string JobLocation { get; set; }

        [Required]
        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public EmploymentType EmploymentType { get; set; }
    }
}
