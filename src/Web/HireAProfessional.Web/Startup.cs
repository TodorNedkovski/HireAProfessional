﻿namespace HireAProfessional.Web
{
    using System;
    using System.Reflection;

    using AutoMapper;
    using HireAProfessional.Data;
    using HireAProfessional.Data.Common;
    using HireAProfessional.Data.Common.Repositories;
    using HireAProfessional.Data.Models;
    using HireAProfessional.Data.Repositories;
    using HireAProfessional.Data.Seeding;
    using HireAProfessional.Hubs;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Services.Mapping;
    using HireAProfessional.Services.Messaging;
    using HireAProfessional.Web.ViewModels;
    using HireAProfessionalML.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.ML;
    //using SentimentAnalysisWebAPI.DataModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });

            services.AddControllersWithViews(
                options =>
                    {
                        //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddPredictionEnginePool<ModelInput, ModelOutput>()
              .FromUri(
                  modelName: "SentimentAnalysisModel",
                  uri: @"D:\Git\HireAProfessional\src\Services\HireAProfessionalML.Model\MLModel.zip",
                  period: TimeSpan.FromMinutes(1));
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            services.AddSignalR();

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IPostsService, PostsService>();
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IBlogsService, BlogsService>();
            services.AddTransient<IVotesService, VotesService>();
            services.AddTransient<ICountriesService, CountriesService>();
            services.AddTransient<IApplicationsService, ApplicationsService>();
            services.AddTransient<ICompaniesService, CompaniesService>();
            services.AddTransient<ICommentsService, CommentsService>();
            services.AddTransient<IUsersService, UsersService>();
            services.AddTransient<ILocationsService, LocationsService>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = this.configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = this.configuration["Authentication:Facebook:AppSecret"];
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        //endpoints.MapControllerRoute(
                        //    "dashboard",
                        //    "Administration/Dashboard/{action}/{entity}",
                        //    new { controller = "Dashboard" });
                        endpoints.MapControllerRoute(
                            "post",
                            "Jobs/All/{id}",
                            new { controller = "JobPosts", action = "ById" });
                        endpoints.MapControllerRoute(
                            "posts",
                            "Jobs/All",
                            new { controller = "JobPosts", action = "BySearch" });
                        endpoints.MapControllerRoute(
                            "blog",
                            "Blogs/{name}",
                            new { controller = "Blogs", action = "ByBlogName" });
                        endpoints.MapControllerRoute(
                            "blogs",
                            "Blogs/All",
                            new { controller = "Blogs", action = "AllBlogs" });
                        endpoints.MapHub<ChatHub>("/chat");
                        endpoints.MapControllerRoute("crudOperationsCreate", "{area:exists}/Dashboard/{controller=Home}/CrudOperations/Create");
                        endpoints.MapControllerRoute("statistics", "{area:exists}/Dashboard/{controller=Home}/Statistics{action=Index}");
                        endpoints.MapControllerRoute("dashboardArea", "{area:exists}/Dashboard/{controller=Home}/{action=Index}");
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("externalLogin", "Identity/Account/Login/ExternalLogin");
                        endpoints.MapRazorPages();
                    });
        }
    }
}
