namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        //private readonly ISettingsService settingsService;

        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            //var viewModel = new IndexViewModel { SettingsCount = this.settingsService.GetCount(), };
            //return this.View(viewModel);
            return this.View();
        }
    }
}
