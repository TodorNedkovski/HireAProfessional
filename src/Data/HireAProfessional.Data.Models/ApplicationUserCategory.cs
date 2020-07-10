namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationUserCategory
    {
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
