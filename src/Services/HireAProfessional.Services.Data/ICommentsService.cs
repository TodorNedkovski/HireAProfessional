namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        ICollection<T> GetAll<T>();

        Task<string> CreateComment(string posterId, string parentId, string postId, string content);
    }
}
