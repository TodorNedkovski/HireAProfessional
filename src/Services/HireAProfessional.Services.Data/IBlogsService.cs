namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.Infrastructure.Enums;
    using HireAProfessional.Web.ViewModels.Blogs;

    public interface IBlogsService
    {
        Task Create(BlogInputViewModel post);

        BlogsListViewModel GetAll(int count = int.MaxValue, string param = "Id", OrderType orderType = OrderType.Ascending);

        BlogViewModel GetBlogByTitle(string title);

        BlogViewModel GetBlogById(string id);
    }
}
