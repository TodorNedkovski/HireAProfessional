namespace HireAProfessional.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Json;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using RestSharp;

    public class GeoDbAPIService<T> : IGeoDbAPIService<T>
    {
        private const int NUMBER = 10;
        private readonly IConfiguration configuration;

        public GeoDbAPIService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public GeoDbJsonInputModel<T> Get(int offset, string entity)
        {
            var url = "https://wft-geo-db.p.rapidapi.com/v1/geo/" + $"{entity}?offset={offset}&limit={NUMBER}";

            var key = this.configuration.GetSection("GeoDb:ApiKey").Value;

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "wft-geo-db.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", key);
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<GeoDbJsonInputModel<T>>(response.Content);
        }
    }
}
