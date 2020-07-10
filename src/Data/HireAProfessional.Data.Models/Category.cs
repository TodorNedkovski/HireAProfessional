namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;

    public class Category : BaseDeletableModel<string>
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationUserCategories = new HashSet<ApplicationUserCategory>();
            this.ProfessionalUsers = new HashSet<ProfessionalUser>();
        }

        public string Name { get; set; }

        public int Count => this.ApplicationUserCategories.Count;

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public ICollection<ProfessionalUser> ProfessionalUsers { get; set; }

        public ICollection<ApplicationUserCategory> ApplicationUserCategories { get; set; }
    }
}
