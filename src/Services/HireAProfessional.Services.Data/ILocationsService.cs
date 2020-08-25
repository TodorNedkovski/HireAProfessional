namespace HireAProfessional.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using HireAProfessional.Web.ViewModels.Locations;

    public interface ILocationsService
    {
        Task CreateAsync(LocationViewModel location);

        Task DeleteAsync(string cityId, string countryId);

        Task EditAsync(string cityId, string countryId, LocationViewModel post);

        IEnumerable<T> GetAll<T>(int take, int skips);
    }
}
