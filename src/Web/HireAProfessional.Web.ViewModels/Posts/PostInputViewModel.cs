namespace HireAProfessional.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models.Enums;

    public class PostInputViewModel
    {
        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public string JobLocation { get; set; }

        public EmploymentType EmploymentType { get; set; }
    }
}
