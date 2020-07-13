﻿// <auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using HireAProfessional.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using HireAProfessional.Services.Data;
using System.Collections.Immutable;
using HireAProfessional.Web.ViewModels.Categories;

namespace HireAProfessional.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IRegisterService _registerService;
        private readonly ICategoriesService _categoryService;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IRegisterService registerService,
            ICategoriesService categoryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _registerService = registerService;
            _categoryService = categoryService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IEnumerable<CategoryRegisterViewModel> Categories
            => this._categoryService.GetAllCategoriesWithoutViewModel()
            .Select(c => new CategoryRegisterViewModel { Name = c.Name });

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            [DataType(DataType.Text)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [DataType(DataType.Text)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Age")]
            [DataType(DataType.Text)]
            public int Age { get; set; }

            [Required]
            [Display(Name = "Company")]
            [DataType(DataType.Text)]
            public string Company { get; set; }

            [Required]
            [Display(Name = "Education")]
            [DataType(DataType.Text)]
            public string Education { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Role { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public string Category { get; set; }

            [Required]
            [Display(Name = "Twitter Account Link")]
            [DataType(DataType.Text)]
            public string TwitterAccountLink { get; set; }

            [Required]
            [Display(Name = "Facebook Account Link")]
            [DataType(DataType.Text)]
            public string FacebookAccountLink { get; set; }

            [Required]
            [Display(Name = "Indeed Account Link")]
            [DataType(DataType.Text)]
            public string IndeedAccountLink { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [DataType(DataType.ImageUrl)]
            [Display(Name = "Please upload a picture")]
            public string ImageUrl { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    UserName = this.Input.Email,
                    Email = this.Input.Email,
                    FirstName = this.Input.FirstName,
                    LastName = this.Input.LastName,
                    Age = this.Input.Age,
                    FacebookAccountLink = this.Input.FacebookAccountLink,
                    Education = this.Input.Education,
                    Company = this.Input.Company,
                    ImageUrl = this.Input.ImageUrl,
                    TwitterAccountLink = this.Input.TwitterAccountLink,
                    Points = 100,
                };

                var category = this._categoryService.GetAllCategoriesWithoutViewModel().FirstOrDefault(c => c.Name == this.Input.Category);

                var result = await _userManager.CreateAsync(user, this.Input.Password);

                if (this.Input.Role == "Professional")
                {
                    await this._registerService.MakeUserProfessional(user, category);
                }

                await this._userManager.AddToRoleAsync(user, this.Input.Role);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
