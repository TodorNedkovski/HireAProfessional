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

        public int Name { get; set; }

        public int Age { get; set; }

        public Category Category { get; set; }

        public string CategoryId { get; set; }
    }
}
