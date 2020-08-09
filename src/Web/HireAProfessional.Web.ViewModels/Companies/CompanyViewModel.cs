namespace HireAProfessional.Web.ViewModels.Companies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Web.ViewModels.Applications;
    using HireAProfessional.Web.ViewModels.ApplicationUsers;
    using HireAProfessional.Web.ViewModels.Posts;

    public class CompanyViewModel : IMapFrom<Company>, IMapTo<CompanyViewModel>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<ApplicationUserViewModel> Employees { get; set; }

        public ICollection<ApplicationViewModel> Applications { get; set; }

        public ICollection<PostViewModel> JobPosts { get; set; }
    }
}
