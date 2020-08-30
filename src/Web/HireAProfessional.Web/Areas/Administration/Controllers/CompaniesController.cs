namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class CompaniesController : Controller
    {
        private readonly ICompaniesService companiesService;

        public CompaniesController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        [Route("Administration/Dashboard/Companies/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Companies"));
        }

        [Route("Administration/Dashboard/Companies/CrudOperations")]
        public IActionResult CrudOperations(int page = 1)
        {
            var count = this.companiesService.GetAll<CompanyViewModel>(int.MaxValue, 0).Count();

            var companies = this.companiesService.GetAll<CompanyViewModel>(10, (page - 1) * 10);

            var model = new CompaniesListViewModel
            {
                Companies = companies,
                CurrentPage = page,
                PagesCount = (int)Math.Ceiling((double)count / 10),
            };

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Companies"), model);
        }
    }
}
