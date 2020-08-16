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

        PostsListViewModel GetAllPosts(int count = int.MaxValue, int skip = 0, string param = "Id", string jobConstraints = "all", string location = "all", OrderType orderType = OrderType.Ascending);

        PostViewModel GetPostById(string id, string userId);

        PostsListViewModel GetAllPostsByCategory(string categoryName);
    }
}
