namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;
    using System.Threading;

    using HireAProfessional.Data.Common.Models;

    public class Professional : BaseDeletableModel<string>
    {
        public Professional()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public Category Category { get; set; }

        public string CategoryId { get; set; }

        public string Company { get; set; }

        public string Education { get; set; }

        public string TwitterAccountLink { get; set; }

        public string LinkedInAccountLink { get; set; }

        public string FacebookAccountLink { get; set; }
    }
}
