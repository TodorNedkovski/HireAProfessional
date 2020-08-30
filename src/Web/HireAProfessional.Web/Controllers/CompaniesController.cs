namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard.Companies;
    using HireAProfessional.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompaniesService companyService;

        public CompaniesController(ICompaniesService companyService)
        {
            this.companyService = companyService;
        }

        //public ActionResult<IEnumerable<DashboardCompanyViewModel>> Get()
        //{
        //    return this.companyService.GetAll<DashboardCompanyViewModel>().ToList();
        //}
    }
}
