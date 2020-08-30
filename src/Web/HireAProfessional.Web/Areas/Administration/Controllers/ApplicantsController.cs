namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Applications;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class ApplicantsController : Controller
    {
        private readonly IApplicationsService applicationsService;

        public ApplicantsController(IApplicationsService applicationsService)
        {
            this.applicationsService = applicationsService;
        }

        [Route("Administration/Dashboard/Applicants/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Applicants"));
        }

        [Route("Administration/Dashboard/Applicants/CrudOperations")]
        public IActionResult CrudOperations(int page = 1)
        {
            var count = this.applicationsService.GetAll<ApplicationViewModel>(int.MaxValue, 0).Count();
            var applications = this.applicationsService.GetAll<ApplicationViewModel>(10, (page - 1) * 10);

            var model = new ApplicationListViewModel
            {
                Applications = applications,
                CurrentPage = page,
                PagesCount = (int)Math.Ceiling((double)count / 10),
            };

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Applicants"), model);
        }
    }
}
