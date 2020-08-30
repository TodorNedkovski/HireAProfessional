namespace HireAProfessional.Web.Areas.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HireAProfessional.Services.Data;
    using HireAProfessional.Web.ViewModels.Locations;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class LocationsApiController : ControllerBase
    {
        private readonly ILocationsService locationsService;

        public LocationsApiController(ILocationsService locationsService)
        {
            this.locationsService = locationsService;
        }

        [Route("api/locations/delete")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LocationResponseModel>> Delete(LocationRequestModel input)
        {
            await this.locationsService.DeleteAsync(input.CityId, input.CountryId);

            return new LocationResponseModel { };
        }

        [Route("api/locations/create")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LocationResponseModel>> Create(LocationRequestModel input)
        {
            await this.locationsService.CreateAsync(new LocationViewModel
            {
                CityName = input.CityName,
                CountryName = input.CountryName,
            });

            return new LocationResponseModel { };
        }
    }
}
