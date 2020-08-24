namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Blogs;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Server.IIS.Core;

    [ApiController]
    public class BlogsApiController : ControllerBase
    {
        private readonly IBlogsService blogsService;

        public BlogsApiController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        [Route("api/blogs/create")]
        public async Task<IActionResult> Create(BlogRequestModel input)
        {
            await this.blogsService.CreateAsync(new BlogInputViewModel
            {
                Title = input.BlogTitle,
                Content = input.Content,
                AuthorId = input.AuthorId,
            });

            return this.RedirectToAction("CrudOperations");
        }

        [Route("api/blogs/delete")]
        public async Task<ActionResult<BlogResponseModel>> Delete(BlogRequestModel input)
        {
            await this.blogsService.DeleteAsync(input.BlogId);

            return new BlogResponseModel { };
        }

        [Route("api/blogs/edit")]
        public async Task<IActionResult> Edit(BlogRequestModel input)
        {
            await this.blogsService.EditAsync(input.BlogId, new BlogInputViewModel
            {
                Title = input.BlogTitle,
                Content = input.Content,
                AuthorId = input.AuthorId,
            });

            return this.RedirectToAction("CrudOperations");
        }
    }
}
