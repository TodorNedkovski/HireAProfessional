namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class BlogsController : Controller
    {
        [Route("Administration/Dashboard/Blogs/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Blogs"));
        }

        [Route("Administration/Dashboard/Blogs/CrudOperations")]
        public IActionResult CrudOperations()
        {
            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Blogs"));
        }
    }
}
