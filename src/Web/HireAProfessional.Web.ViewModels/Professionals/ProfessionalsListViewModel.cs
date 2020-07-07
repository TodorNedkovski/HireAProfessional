namespace HireAProfessional.Web.ViewModels.Professionals
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;

    public class ProfessionalsListViewModel
    {
        public IEnumerable<ProfessionalViewModel> Professionals { get; set; }
    }
}
