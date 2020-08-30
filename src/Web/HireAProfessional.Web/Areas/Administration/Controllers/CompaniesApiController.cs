namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;


    [ApiController]
    public class CompaniesApiController : ControllerBase
    {
        private readonly ICompaniesService companiesService;

        public CompaniesApiController(ICompaniesService companiesService)
        {
            this.companiesService = companiesService;
        }

        [Route("api/companies/create")]
        public async Task<ActionResult<CompanyResponseModel>> Create(CompanyRequestModel input)
        {
            await this.companiesService.AddAsync(input.CompanyName);

            return new CompanyResponseModel { };
        }

        [Route("api/companies/delete")]
        public async Task<ActionResult<CompanyResponseModel>> Delete(CompanyRequestModel input)
        {
            await this.companiesService.DeleteAsync(input.CompanyId);

            return new CompanyResponseModel { };
        }
    }
}
