namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Posts;

    public interface IPostService
    {
        Task CreatePost(PostInputViewModel post);

        PostAllViewModel GetAllPosts();

        PostAllViewModel GetAllPostsByCategory(string categoryName);
    }
}
