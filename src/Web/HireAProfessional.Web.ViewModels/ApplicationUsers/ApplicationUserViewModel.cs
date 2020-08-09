namespace HireAProfessional.Web.ViewModels.ApplicationUsers
{
    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Companies;

    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>, IMapTo<ApplicationUserViewModel>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string CompanyId { get; set; }

        public CompanyViewModel Company { get; set; }

        public string Education { get; set; }

        public string TwitterAccountLink { get; set; }

        public string LinkedInAccountLink { get; set; }

        public string FacebookAccountLink { get; set; }
    }
}
