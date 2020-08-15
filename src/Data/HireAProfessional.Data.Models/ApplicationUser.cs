// ReSharper disable VirtualMemberCallInConstructor
namespace HireAProfessional.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public int Age { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        [Required]
        public string Education { get; set; }

        public int Points { get; set; }

        [Required]
        public string TwitterAccountLink { get; set; }

        [Required]
        public string LinkedInAccountLink { get; set; }

        [Required]
        public string FacebookAccountLink { get; set; }

        public ICollection<JobPost> Posts { get; set; }

        public ICollection<Blog> Blogs { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<Application> Applications { get; set; }

        public ICollection<UserReport> UserReports { get; set; }

        public ICollection<UserReport> ReportedByUsers { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public ICollection<ApplicationUserCategory> ApplicationUserCategories { get; set; }
    }
}
