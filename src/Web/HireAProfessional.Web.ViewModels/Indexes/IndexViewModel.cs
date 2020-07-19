namespace HireAProfessional.Web.ViewModels.Indexes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Blogs;
    using HireAProfessional.Web.ViewModels.Categories;
    using HireAProfessional.Web.ViewModels.Posts;

    public class IndexViewModel
    {
        public CategoriesListViewModel CategoriesListViewModel { get; set; }

        public BlogsListViewModel BlogsListViewModel { get; set; }

        public PostsListViewModel PostsListViewModel { get; set; }
    }
}
