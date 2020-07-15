﻿namespace HireAProfessional.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;

    public class PostViewModel
    {
        public string JobTitle { get; set; }

        public string Company { get; set; }

        public string Description { get; set; }

        public Category Category { get; set; }

        public string JobLocation { get; set; }

        public EmploymentType EmploymentType { get; set; }
    }
}
