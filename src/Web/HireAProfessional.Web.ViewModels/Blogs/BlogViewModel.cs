namespace HireAProfessional.Web.ViewModels.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;

    public class BlogViewModel : IMapFrom<Blog>, IMapTo<BlogViewModel>
    {
        public string Id { get; set; }

        public ApplicationUserViewModel Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
