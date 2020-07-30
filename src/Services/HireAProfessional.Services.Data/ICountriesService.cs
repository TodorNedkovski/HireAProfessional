namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Countries;

    public interface ICountriesService
    {
        IEnumerable<T> GetAllCountries<T>();
    }
}
