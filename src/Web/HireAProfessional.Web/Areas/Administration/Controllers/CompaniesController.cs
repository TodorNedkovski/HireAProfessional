namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class CompaniesController : Controller
    {
        [Route("Administration/Dashboard/Companies/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Companies"));
        }

        [Route("Administration/Dashboard/Companies/CrudOperations")]
        public IActionResult CrudOperations()
        {
            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Companies"));
        }
    }
}
