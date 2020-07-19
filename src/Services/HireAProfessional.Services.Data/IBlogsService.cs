namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Blogs;

    public interface IBlogsService
    {
        Task CreateBlog(BlogInputViewModel post);

        BlogsListViewModel GetAllBlogs();

        BlogViewModel GetBlogByTitle(string title);

        BlogViewModel GetBlogById(string id);
    }
}
