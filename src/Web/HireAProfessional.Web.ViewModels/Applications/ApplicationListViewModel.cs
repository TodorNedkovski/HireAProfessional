namespace HireAProfessional.Web.ViewModels.Applications
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ApplicationListViewModel
    {
        public IEnumerable<ApplicationViewModel> Applications { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
