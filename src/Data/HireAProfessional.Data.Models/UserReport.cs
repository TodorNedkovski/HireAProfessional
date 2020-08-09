namespace HireAProfessional.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using HireAProfessional.Data.Common.Models;
    using HireAProfessional.Data.Models.Enums;

    public class UserReport : BaseDeletableModel<string>
    {
        public UserReport()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ReporterId { get; set; }

        public ApplicationUser Reporter { get; set; }

        [Required]
        [MaxLength(4000)]
        public string Content { get; set; }

        [Required]
        public string ReportedUserId { get; set; }

        public ApplicationUser ReportedUser { get; set; }

        public IssueType IssueType { get; set; }
    }
}
