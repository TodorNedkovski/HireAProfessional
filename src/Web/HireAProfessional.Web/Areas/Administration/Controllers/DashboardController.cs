namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using HireAProfessional.Services.Data;

    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class DashboardController : AdministrationController
    {
        public DashboardController()
        {
        }

        public IActionResult Index()
        {
            return this.View();
        }
    }
}
