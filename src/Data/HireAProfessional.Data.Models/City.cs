namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using RestSharp;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public string CountryCode { get; set; }

        public string Region { get; set; }
    }
}
