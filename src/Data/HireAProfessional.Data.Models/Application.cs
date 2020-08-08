namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;

    public class Application : BaseDeletableModel<string>
    {
        public Application()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
