namespace HireAProfessional.Web.ViewModels.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BlogsListViewModel
    {
        public ICollection<BlogViewModel> Blogs { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
