namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    using HireAProfessional.Data.Common.Models;

    public class Professional : BaseDeletableModel<string>
    {
        public Professional()
        {
            this.IsDeleted = false;
            this.DeletedOn = null;
        }

        public int Name { get; set; }

        public int Age { get; set; }

        public Category Fild { get; set; }
    }
}
