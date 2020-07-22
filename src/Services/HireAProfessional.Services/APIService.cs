namespace HireAProfessional.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;

    using HireAProfessional.Web.ViewModels.Json;
    using Newtonsoft.Json;
    using RestSharp;

    public static class APIService<T>
    {
        private const int NUMBER = 10;

        public static JsonInputModel<T> GetCountries(int offset, string entity)
        {
            var url = "https://wft-geo-db.p.rapidapi.com/v1/geo/" + $"{entity}?offset={offset}&limit={NUMBER}";

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "wft-geo-db.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "b1fc7fe185mshfa78e7b8f7c3d7fp134043jsnce488d5141b9");
            IRestResponse response = client.Execute(request);

            return JsonConvert.DeserializeObject<JsonInputModel<T>>(response.Content);
        }
    }
}
