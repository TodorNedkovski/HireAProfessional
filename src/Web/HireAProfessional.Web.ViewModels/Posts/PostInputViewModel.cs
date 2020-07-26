namespace HireAProfessional.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HireAProfessional.Data.Models.Enums;

    public class PostInputViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        public string JobTitle { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string CompanyName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string JobLocation { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public EmploymentType EmploymentType { get; set; }
    }
}
