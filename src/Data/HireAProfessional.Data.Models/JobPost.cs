﻿namespace HireAProfessional.Data.Models
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
            this.Votes = new HashSet<Vote>();
        }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        public string Company { get; set; }

        public string LocationId { get; set; }

        public Location Location { get; set; }

        [Required]
        public double StartingSalary { get; set; }

        [Required]
        public double? HighestSalary { get; set; }

        [Required]
        public string Description { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public EmploymentType EmploymentType { get; set; }

        public ICollection<Vote> Votes { get; set; }
    }
}
