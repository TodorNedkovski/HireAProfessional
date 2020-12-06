namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CommentsApi : ControllerBase
    {
        private ICommentsService commentsService;

        public CommentsApi(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        public async Task<ActionResult<List<CommentViewModel>>> Get()
        {
            var comments = this.commentsService.GetAll<CommentViewModel>().ToList();

            return comments;
        }
    }
}
