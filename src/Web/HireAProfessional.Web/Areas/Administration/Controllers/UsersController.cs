namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class UsersController : Controller
    {
        [Route("Administration/Dashboard/Users/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Users"));
        }

        [Route("Administration/Dashboard/Users/CrudOperations")]
        public IActionResult CrudOperations()
        {
            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Users"));
        }
    }
}
