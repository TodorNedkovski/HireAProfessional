namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        private readonly ICompanyService companyService;

        public DashboardController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Companies()
        {
            var companiesList = this.companyService.GetAllCompanies<DashboardCompanyViewModel>();

            return this.View(companiesList);
        }

        public IActionResult Users()
        {
            return this.View();
        }
    }
}
