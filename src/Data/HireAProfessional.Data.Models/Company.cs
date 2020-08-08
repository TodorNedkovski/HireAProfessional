namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using HireAProfessional.Data.Models.Enums;

    public class Company : BaseDeletableModel<string>
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Employees = new HashSet<ApplicationUser>();
            this.Applications = new HashSet<Application>();
            this.JobPosts = new HashSet<JobPost>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<JobPost> JobPosts { get; set; }
    }
}
