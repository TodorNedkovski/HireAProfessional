namespace HireAProfessional.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Common;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Locations;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class LocationsController : Controller
    {
        private readonly ILocationsService locationsService;

        public LocationsController(ILocationsService locationsService)
        {
            this.locationsService = locationsService;
        }

        [Route("Administration/Dashboard/Locations/Statistics")]
        public IActionResult Statistics()
        {
            return this.View(string.Format(ViewPaths.StatisticsCompaniesViewPath, "Locations"));
        }

        [Route("Administration/Dashboard/Locations/CrudOperations")]
        public IActionResult CrudOperations(int page = 1)
        {
            var count = this.locationsService.GetAll<LocationViewModel>(int.MaxValue, 0).Count();

            var locationsListModel = new LocationListViewModel
            {
                Locations = this.locationsService.GetAll<LocationViewModel>(10, (page - 1) * 10),
                CurrentPage = page,
                PagesCount = (int)Math.Ceiling((double)count / 10),
            };

            return this.View(string.Format(ViewPaths.CrudOperationsViewPath, "Locations"), locationsListModel);
        }
    }
}
