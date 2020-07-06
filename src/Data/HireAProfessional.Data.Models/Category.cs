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
            this.Professionals = new HashSet<Professional>();
        }

        public string Name { get; set; }

        public int Count => this.Professionals.Count;

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public ICollection<Professional> Professionals { get; set; }
    }
}
