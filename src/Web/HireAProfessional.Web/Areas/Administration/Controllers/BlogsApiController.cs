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

    [ApiController]
    public class BlogsApiController : ControllerBase
    {
        private readonly IBlogsService blogsService;

        public BlogsApiController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        [Route("Administration/Dashboard/Blogs/CrudOperations/Create")]
        public async Task<IActionResult> Create(string title, string content, string authorId)
        {
            await this.blogsService.Create(new BlogInputViewModel
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
            });

            return this.RedirectToAction("CrudOperations");
        }

        [Route("Administration/Dashboard/Blogs/CrudOperations/Delete")]
        public async Task<IActionResult> Delete(string title, string content, string authorId)
        {
            await this.blogsService.Create(new BlogInputViewModel
            {
                Title = title,
                Content = content,
                AuthorId = authorId,
            });

            return this.RedirectToAction("CrudOperations");
        }

        [Route("Administration/Dashboard/Blogs/CrudOperations/Edit")]
        public async Task<IActionResult> Edit(string title, string content, string authorId)
        {
            //await this.blogsService.Create(new BlogInputViewModel
            //{
            //    Title = title,
            //    Content = content,
            //    AuthorId = authorId,
            //});

            return this.RedirectToAction("CrudOperations");
        }
    }
}
