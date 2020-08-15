namespace HireAProfessional.Web.ViewModels.Comments
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Ganss.XSS;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Posts;

    public class CommentViewModel : IMapFrom<Comment>, IMapTo<CommentViewModel>
    {
        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ParentId { get; set; }

        public CommentViewModel Parent { get; set; }

        public string PosterId { get; set; }

        public ApplicationUserViewModel Poster { get; set; }

        public string PostId { get; set; }

        public PostViewModel Post { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
