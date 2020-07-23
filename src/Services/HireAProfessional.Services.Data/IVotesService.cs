namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IVotesService
    {
        Task VoteAsync(string postId, string userId, bool isUpVote);

        int GetVotesCount(string postId);
    }
}
