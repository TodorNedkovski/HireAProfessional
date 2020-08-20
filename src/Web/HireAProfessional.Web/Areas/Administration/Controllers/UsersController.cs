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
        public IActionResult CrudOperations(int page = 1)
        {
            var users = this.usersService.GetAll<ApplicationUserViewModel>(10, (page - 1) * 10);
            var count = this.usersService.GetAll<ApplicationUserViewModel>(int.MaxValue, 0).Count();

            var model = new CrudApplicationUserViewModel
            {
                Users = users,
                CurrentPage = page,
                PagesCount = (int)Math.Ceiling((double)count / 10),
            };

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Users"), model);
        }
    }
}
