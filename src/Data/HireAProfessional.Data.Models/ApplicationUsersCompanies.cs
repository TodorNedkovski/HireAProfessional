namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationUsersCompanies
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }
    }
}
