namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class LocationsController : Controller
    {
        [Route("Administration/Dashboard/Locations/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Locations"));
        }

        [Route("Administration/Dashboard/Locations/CrudOperations")]
        public IActionResult CrudOperations()
        {
            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Locations"));
        }
    }
}
