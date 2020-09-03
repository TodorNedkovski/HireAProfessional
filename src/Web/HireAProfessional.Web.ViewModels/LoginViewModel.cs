namespace HireAProfessional.Web.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;

    using Microsoft.AspNetCore;

    public class LoginViewModel<T>
    {
        public string ReturnUrl { get; set; }

        public ICollection<T> ExternalLogins { get; set; }
    }
}
