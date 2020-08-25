namespace HireAProfessional.Web.ViewModels.Locations
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocationListViewModel
    {
        public IEnumerable<LocationViewModel> Locations { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
