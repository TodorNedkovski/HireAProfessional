namespace HireAProfessional.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using HireAProfessional.Services.Data;
    using HireAProfessional.Services.Json;
    using HireAProfessional.Web.ViewModels.Countries;
    using HireAProfessional.Web.ViewModels.Votes;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private ICountriesService countryService;

        public CountriesController(ICountriesService countryService)
        {
            this.countryService = countryService;
        }

        public async Task<ActionResult<IEnumerable<CountryViewModel>>> Get()
        {
            var countries = this.countryService.GetAllCountries<CountryViewModel>().ToList();

            return countries;
        }
    }
}
