namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Applications;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ApplicationApiController : ControllerBase
    {
        private readonly IApplicationsService applicationsService;

        public ApplicationApiController(IApplicationsService applicationsService)
        {
            this.applicationsService = applicationsService;
        }

        [Route("api/applications/approve")]
        public async Task<ActionResult<ApplicationResponseViewModel>> Approve(ApplicationRequestViewModel input)
        {
            await this.applicationsService.Approve(input.Id);

            return new ApplicationResponseViewModel { };
        }
    }
}
