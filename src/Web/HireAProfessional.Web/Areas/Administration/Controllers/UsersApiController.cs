namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUsersService usersService;
        private readonly ICompaniesService companiesService;

        public UsersApiController(IUsersService usersService, ICompaniesService companiesService)
        {
            this.usersService = usersService;
            this.companiesService = companiesService;
        }

        [Route("api/users/delete")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DeleteUserResponseViewModel>> Delete(DeleteUserRequestViewModel input)
        {
            await this.usersService.DeleteAsync(input.UserId);

            return new DeleteUserResponseViewModel { };
        }

        [Route("api/users/edit")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<DeleteUserResponseViewModel>> Edit(RegisterUserInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var company = this.companiesService.GetAllCompanies<CompanyViewModel>().FirstOrDefault(c => c.Name == input.CompanyName);

            var user = new ApplicationUser
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Age = input.Age,
                Email = input.Email,
                CompanyId = company.Id,
                Education = input.Education,
            };

            await this.usersService.UpdateAsync(input.Id, user);

            return new DeleteUserResponseViewModel { };
        }
    }
}
