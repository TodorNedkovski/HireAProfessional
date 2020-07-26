﻿namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using RestSharp;

    public class City : BaseDeletableModel<string>
    {
        public City()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [Required]
        public string Region { get; set; }
    }
}
