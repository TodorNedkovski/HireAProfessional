namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProfessionalUser
    {
        public ProfessionalUser()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
