namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Routing;

    [Area("Administration")]
    public class DashboardController : Controller
    {
        private readonly ICompaniesService companyService;

        public DashboardController(ICompaniesService companyService)
        {
            this.companyService = companyService;
        }

        [Route("Administration/Dashboard")]
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Companies()
        {
            return this.View();
        }

        public IActionResult Users()
        {
            return this.View();
        }

        public IActionResult Categories()
        {
            return this.View();
        }

        public IActionResult Posts()
        {
            return this.View();
        }

        public IActionResult Locations()
        {
            return this.View();
        }

        public IActionResult Blogs()
        {
            return this.View();
        }

        public IActionResult Applicants()
        {
            return this.View();
        }

    }
}
