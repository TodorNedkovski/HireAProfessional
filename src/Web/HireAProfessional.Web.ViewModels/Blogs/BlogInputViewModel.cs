namespace HireAProfessional.Web.ViewModels.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.ApplicationUsers;

    public class BlogInputViewModel
    {
        public string AuthorId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
