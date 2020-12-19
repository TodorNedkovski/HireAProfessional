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

        Task DeleteAsync(string postId);

        PostsListViewModel GetAllPosts(int count = int.MaxValue, int skip = 0, string param = "Id", string jobConstraints = null, string location = "all", string categoryName = ".Net Back End Enginner", OrderType orderType = OrderType.Ascending);

        PostViewModel GetPostById(string id, string userId);

        PostsListViewModel GetAllPostsByCategory(string categoryName);

        int GetCountsBySearch(string param = "Id", string jobConstraints = "all", string location = "all", OrderType orderType = OrderType.Ascending);
    }
}
