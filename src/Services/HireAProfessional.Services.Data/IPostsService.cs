namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task CreatePost(PostInputViewModel post);

        PostsListViewModel GetAllPosts(int count = int.MaxValue, string param = "Id", OrderType orderType = OrderType.Ascending);

        PostViewModel GetPostById(string id);

        PostsListViewModel GetAllPostsByCategory(string categoryName);
    }
}
