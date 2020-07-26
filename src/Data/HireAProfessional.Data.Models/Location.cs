namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;

    public class Location : BaseDeletableModel<string>
    {
        public Location()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cites = new HashSet<City>();
        }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<City> Cites { get; set; }
    }
}
