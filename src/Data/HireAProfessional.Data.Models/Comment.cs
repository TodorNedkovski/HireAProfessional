namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Common.Models;

    public class Comment : BaseDeletableModel<string>
    {
        public Comment()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string ParentId { get; set; }

        public Comment Parent { get; set; }

        public string PosterId { get; set; }

        public ApplicationUser Poster { get; set; }

        public string PostId { get; set; }

        public JobPost Post { get; set; }

        public string Content { get; set; }

        public bool IsRemovedByBot { get; set; }
    }
}
