namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Route("Administration/Dashboard/Users/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Users"));
        }

        [Route("Administration/Dashboard/Users/CrudOperations")]
        public IActionResult CrudOperations()
        {
            var users = this.usersService.GetAll<ApplicationUserViewModel>();

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Users"), users);
        }
    }
}
