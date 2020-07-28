namespace HireAProfessional.Web.ViewModels.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Ctites;

    public class JobLocationViewModel
    {
        public string CountryName { get; set; }

        public ICollection<CitiesViewModel> Cities { get; set; }
    }
}
