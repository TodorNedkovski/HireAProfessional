namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/users")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUsersService usersService;

        public UsersApiController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DeleteUserResponseViewModel>> Delete(DeleteUserRequestViewModel input)
        {
            await this.usersService.Delete(input.UserId);

            return new DeleteUserResponseViewModel { };
        }
    }
}
