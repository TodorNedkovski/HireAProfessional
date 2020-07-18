// ReSharper disable VirtualMemberCallInConstructor
namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;

    using HireAProfessional.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.ApplicationUserCategories = new HashSet<ApplicationUserCategory>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string ImageUrl { get; set; }

        public string Company { get; set; }

        public string Education { get; set; }

        public int Points { get; set; }

        public string TwitterAccountLink { get; set; }

        public string LinkedInAccountLink { get; set; }

        public string FacebookAccountLink { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<ApplicationUserCategory> ApplicationUserCategories { get; set; }

        public ICollection<Post> Posts { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
