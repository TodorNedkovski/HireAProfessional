namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.Infrastructure.Enums;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class BlogsController : Controller
    {
        private readonly IBlogsService blogsService;

        public BlogsController(IBlogsService blogsService)
        {
            this.blogsService = blogsService;
        }

        [Route("Administration/Dashboard/Blogs/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Blogs"));
        }

        [Route("Administration/Dashboard/Blogs/CrudOperations")]
        public IActionResult CrudOperations()
        {
            var blogs = this.blogsService.GetAll(int.MaxValue, 0, "Id", OrderType.Ascending);

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Blogs"), blogs);
        }
    }
}
