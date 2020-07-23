namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using HireAProfessional.Data.Models.Enums;

    public class JobPost : BaseDeletableModel<string>
    {
        public JobPost()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string JobLocation { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public EmploymentType EmploymentType { get; set; }
    }
}
