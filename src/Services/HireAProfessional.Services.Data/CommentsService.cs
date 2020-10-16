namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentRepo)
        {
            this.commentRepository = commentRepo;
        }

        public async Task<string> CreateComment(string posterId, string parentId, string postId, string content, bool isRude)
        {
            parentId = parentId == "0" ? null : parentId;

            var comment = new Comment
            {
                PosterId = posterId,
                ParentId = parentId,
                PostId = postId,
                Content = content,
                IsRemovedByBot = isRude,
            };

            await this.commentRepository.AddAsync(comment);

            await this.commentRepository.SaveChangesAsync();

            return comment.Id;
        }

        public ICollection<T> GetAll<T>()
        {
            return this.commentRepository
                .AllAsNoTracking()
                .To<T>()
                .ToList();
        }
    }
}
