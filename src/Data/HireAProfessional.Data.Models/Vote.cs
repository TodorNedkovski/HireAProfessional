namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using HireAProfessional.Data.Common.Models;
    using HireAProfessional.Data.Models.Enums;

    public class Vote : BaseModel<int>
    {
        [Required]
        public string JobPostId { get; set; }

        public JobPost JobPost { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public VoteType VoteType { get; set; }
    }
}
