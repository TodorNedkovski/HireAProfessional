namespace HireAProfessional.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;

    public class PostsListViewModel
    {
        public ICollection<PostViewModel> Posts { get; set; }
    }
}
