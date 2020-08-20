namespace HireAProfessional.Web.ViewModels.ApplicationUsers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrudApplicationUserViewModel
    {
        public IEnumerable<ApplicationUserViewModel> Users { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
