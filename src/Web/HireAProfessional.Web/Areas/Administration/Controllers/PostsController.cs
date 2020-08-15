namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class PostsController : Controller
    {
        [Route("Administration/Dashboard/Posts/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Posts"));
        }

        [Route("Administration/Dashboard/Posts/CrudOperations")]
        public IActionResult CrudOperations()
        {
            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Posts"));
        }
    }
}
