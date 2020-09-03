namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class PostsApiController : ControllerBase
    {
        private readonly IPostsService postsService;

        public PostsApiController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        [Route("api/posts/delete")]
        public async Task<ActionResult<PostResponseModel>> Delete(PostRequestModel input)
        {
            await this.postsService.DeleteAsync(input.PostId);

            return new PostResponseModel { };
        }
    }
}
