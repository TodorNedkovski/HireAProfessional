namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class VotesService : IVotesService
    {
        private IRepository<Vote> voteRepository;
        private IDeletableEntityRepository<JobPost> jobPostRepository;

        public VotesService(IRepository<Vote> voteRepository, IDeletableEntityRepository<JobPost> jobPostRepository)
        {
            this.voteRepository = voteRepository;
            this.jobPostRepository = jobPostRepository;
        }

        public int GetVotesCount(string postId)
        {
            var votesCount = this.voteRepository
                .AllAsNoTracking()
                .Where(p => p.JobPostId == postId)
                .ToList()
                .Count;

            return votesCount;
        }

        public async Task VoteAsync(string postId, string userId, bool isUpVote)
        {
            var vote = this.voteRepository
                .All()
                .FirstOrDefault(v => v.ApplicationUserId == userId && v.JobPostId == postId);

            if (vote != null)
            {
                vote.VoteType = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                await this.voteRepository.AddAsync(new Vote
                {
                    JobPostId = postId,
                    ApplicationUserId = userId,
                    VoteType = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                });
            }

            await this.voteRepository.SaveChangesAsync();
        }
    }
}
