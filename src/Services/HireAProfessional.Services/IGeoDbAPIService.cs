namespace HireAProfessional.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Json;

    public interface IGeoDbAPIService<T>
    {
        public GeoDbJsonInputModel<T> Get(int offset, string entity);
    }
}
