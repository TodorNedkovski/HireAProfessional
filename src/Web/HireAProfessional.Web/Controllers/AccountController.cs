namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using HireAProfessional.Data.Models;
    using HireAProfessional.Web.ViewModels;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        public IActionResult ExternalLogin(string provider, string returnUrl)
        {
            var redirectUrl = this.Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });

            var properties = this.signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> ExternalLoginCallback(string remoteError = null, string returnUrl = null)
        {
            returnUrl = returnUrl ?? this.Url.Content("/");

            //var loginViewModel = new LoginViewModel<AuthenticationScheme>
            //{
            //    ReturnUrl = returnUrl,
            //    ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            //};

            if (remoteError != null)
            {
                this.ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");

                return this.View("Login");
            }

            var info = await this.signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                return this.BadRequest();
            }

            var signInResult = await this.signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);

            if (signInResult.Succeeded)
            {
                return this.LocalRedirect(returnUrl);
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);

            var user = await this.userManager.FindByEmailAsync(email);

            if (user == null)
            {
                await this.userManager.CreateAsync(new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Points = 100,
                });
            }

            await this.userManager.AddLoginAsync(user, info);
            await this.signInManager.SignInAsync(user, isPersistent: false);

            return this.LocalRedirect(returnUrl);
        }
    }
}
