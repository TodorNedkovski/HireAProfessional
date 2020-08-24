namespace HireAProfessional.Web.ViewModels.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BlogRequestModel
    {
        public string BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }
    }
}
