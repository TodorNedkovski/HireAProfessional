namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Applications;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Formatters;

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private IApplicationService applicationService;

        public ApplicationsController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ApplicationResponseViewModel>> Apply(ApplicationRequestViewModel input)
        {
            await this.applicationService.CreateApplicationAsync(input.ApplicationUserId, input.CompanyId);

            return new ApplicationResponseViewModel
            {
            };
        }
    }
}
